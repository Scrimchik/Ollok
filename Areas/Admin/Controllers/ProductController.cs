using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private ISizeRepository sizeRepository;
        private ApplicationDbContext db;
        private IWebHostEnvironment webHostEnvironment;
        private ICategoryRepository categoryRepository;
        public IConfiguration Configuration { get; }
        int productPerPage = 12;

        public ProductController(IProductRepository productRepository, 
            ISizeRepository sizeRepository, 
            ApplicationDbContext context, 
            IWebHostEnvironment webHostEnvironment,
            ICategoryRepository categoryRepository,
            IConfiguration configuration)
        {
            this.productRepository = productRepository;
            this.sizeRepository = sizeRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.categoryRepository = categoryRepository;
            Configuration = configuration;
            db = context;
        }

        public async Task<IActionResult> Product(int productPage = 1)
        {
            return View(await productRepository.Products.Skip((productPage - 1) * productPerPage).Take(productPerPage).Include(t => t.Photos).ToListAsync());
        }

        public async Task<IActionResult> UpdateProduct(int productId)
        {
            Product product = await productRepository.Products.Where(t => t.Id == productId).Include(t => t.Photos).Include(t => t.Sizes).FirstOrDefaultAsync();
            return View(new UpdateProductViewModel { Sizes = db.Sizes.ToList(), Product = product });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, List<int> sizes, IFormFileCollection photos)
        {
            Product productUpdate = productRepository.Products.Where(t => t.Id == product.Id).Include(t => t.Sizes).Include(t => t.Photos).FirstOrDefault();
            productUpdate.LatinName = product.LatinName;
            productUpdate.Name = product.Name;
            productUpdate.Price = product.Price;
            productUpdate.Color = product.Color;

            await AddPhotosToProduct(photos, productUpdate);
            AddSizesToProduct(sizes, productUpdate, true);
            await db.SaveChangesAsync();
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> DeleteProductPhoto(int productId, int photoId)
        {
            Photo photo = await db.Photos.FirstOrDefaultAsync(t => t.Id == photoId);
            DeletePhoto(photo.PhotoWay);
            db.Photos.Remove(photo);
            await db.SaveChangesAsync();
            return RedirectToAction("UpdateProduct", productId);
        }

        public IActionResult DeleteProduct(int productId)
        {
            Product product = productRepository.Products.Include(t => t.Photos).FirstOrDefault(t => t.Id == productId);
            db.Products.Remove(product);

            foreach (var p in product.Photos)
                DeletePhoto(p.PhotoWay);

            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public IActionResult AddProduct()
        {
            AddProductViewModel model = new AddProductViewModel()
            {
                Sizes = sizeRepository.Sizes.ToList(),
                Categories = categoryRepository.Categories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, List<int> sizes, int categoryId, IFormFileCollection photos)
        {
            Product productUpdate = new Product();
            productUpdate.LatinName = product.LatinName;
            productUpdate.Name = product.Name;
            productUpdate.Price = product.Price;
            productUpdate.Color = product.Color;
            productUpdate.Sizes = product.Sizes;
            productUpdate.CategoryId = categoryId;

            await AddPhotosToProduct(photos, productUpdate);
            AddSizesToProduct(sizes, productUpdate, false);
            db.Products.Add(productUpdate);
            await db.SaveChangesAsync();
            await SetNewProductToApi();
            return RedirectToAction("Product");
        }

        public IActionResult SearchProduct(string productName)
        {
            return View("Product", productRepository.Products.Include(t => t.Photos).Where(t => t.Name.Contains(productName)));
        }

        public async Task<IActionResult> HideProduct(int productId)
        {
            Product product = await productRepository.Products.FirstOrDefaultAsync(t => t.Id == productId);
            product.IsSeen = false;
            await db .SaveChangesAsync();
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> ShowProduct(int productId)
        {
            Product product = await productRepository.Products.FirstOrDefaultAsync(t => t.Id == productId);
            product.IsSeen = true;
            await db.SaveChangesAsync();
            return RedirectToAction("Product");
        }

        public void AddSizesToProduct(List<int> sizes, Product product, bool updateProduct)
        {
            if (updateProduct) {
                List<Models.Size> sizesObj = sizeRepository.Sizes.Where(t => t.Products.Any(s => s.Id == product.Id)).ToList();
                List<Models.Size> selectedSize = sizeRepository.Sizes.Where(t => sizes.Any(s => s == t.SizeValue)).Include(t => t.Products).ToList();

                foreach (var s in sizesObj)
                    s.Products?.Remove(product);

                foreach (var s in selectedSize)
                    s.Products.Add(product);
            }
            else
            {
                List<Models.Size> selectedSize = sizeRepository.Sizes.Where(t => sizes.Any(s => s == t.SizeValue)).ToList();
                product.Sizes.AddRange(selectedSize);
            }
        }

        public async Task AddPhotosToProduct(IFormFileCollection photos, Product product)
        {
            foreach (var p in photos)
            {
                using (var fileStream = new FileStream(webHostEnvironment.WebRootPath + "/img/products-photo/large/" + p.FileName, FileMode.Create))
                {
                    await p.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(webHostEnvironment.WebRootPath + "/img/products-photo/medium/" + p.FileName, FileMode.Create))
                {
                    await p.CopyToAsync(fileStream);
                }

                Photo photo = new Photo()
                {
                    PhotoWay = p.FileName,
                };
                product.Photos.Add(photo);

                SqueezePhoto(p);
            }

        }

        public void SqueezePhoto(IFormFile photo)
        {
            using (Bitmap bitmap = new Bitmap(webHostEnvironment.WebRootPath + "/img/products-photo/medium/" + photo.FileName))
            {
                System.Drawing.Size size = new System.Drawing.Size(600, 800);
                using (Bitmap newBitmap = new Bitmap(bitmap, size))
                {
                    newBitmap.Save(webHostEnvironment.WebRootPath + "/img/products-photo/large/" + photo.FileName);
                }
            }
            using (Bitmap bitmap = new Bitmap(webHostEnvironment.WebRootPath + "/img/products-photo/large/" + photo.FileName))
            {
                System.Drawing.Size size = new System.Drawing.Size(330, 410);
                using(Bitmap newBitmap = new Bitmap(bitmap, size))
                {
                    newBitmap.Save(webHostEnvironment.WebRootPath + "/img/products-photo/medium/" + photo.FileName);
                }
            }
        }

        public void DeletePhoto(string photoName)
        {
            FileInfo photoMedium = new FileInfo(webHostEnvironment.WebRootPath + "/img/products-photo/medium/" + photoName);
            FileInfo photoLarge = new FileInfo(webHostEnvironment.WebRootPath + "/img/products-photo/large/" + photoName);
            photoMedium.Delete();
            photoLarge.Delete();
        }

        public async Task SetNewProductToApi()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Configuration["Data:ApiUri"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await client.GetAsync("/api/product");
        }
    }
}
