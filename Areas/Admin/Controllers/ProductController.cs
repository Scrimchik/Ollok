using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private ISizeRepository sizeRepository;
        private IWebHostEnvironment webHostEnvironment;
        private ICategoryRepository categoryRepository;
        private IPhotoRepository photoRepository;
        int productPerPage = 12;

        public ProductController(IProductRepository productRepository, ISizeRepository sizeRepository, 
            ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            ICategoryRepository categoryRepository, IPhotoRepository photoRepository)
        {
            this.productRepository = productRepository;
            this.sizeRepository = sizeRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.categoryRepository = categoryRepository;
            this.photoRepository = photoRepository;
        }

        public async Task<IActionResult> Product(int productPage = 1)
        {
            return View(await productRepository.Products.Skip((productPage - 1) * productPerPage).Take(productPerPage).Include(t => t.Photos).ToListAsync());
        }

        public async Task<IActionResult> UpdateProduct(int productId)
        {
            Product product = await productRepository.GetProductAsync(productId);
            return View(new UpdateProductViewModel { Sizes = await sizeRepository.Sizes.ToListAsync(), Product = product });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, List<int> sizes, IFormFileCollection photos)
        {
            product.Photos.AddRange(await AddPhotosToProduct(photos));

            await productRepository.UpdateProductAsync(product);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> DeleteProductPhoto(int productId, int photoId)
        {
            string photoWay = await photoRepository.Photos.Where(t => t.Id == photoId).Select(t => t.PhotoWay).FirstOrDefaultAsync();
            DeletePhoto(photoWay);
            await photoRepository.DeletePhotoAsync(photoId);
            return RedirectToAction("UpdateProduct", productId);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            Product product = await productRepository.GetProductAsync(productId);

            foreach (var p in product.Photos)
                DeletePhoto(p.PhotoWay);

            await productRepository.DeleteProductAsync(product);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> AddProduct()
        {
            AddProductViewModel model = new AddProductViewModel()
            {
                Sizes = await sizeRepository.Sizes.ToListAsync(),
                Categories = await categoryRepository.Categories.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, List<int> sizes, int categoryId, IFormFileCollection photos)
        {
            product.Photos = await AddPhotosToProduct(photos);
            product.Sizes = await sizeRepository.Sizes.Where(t => sizes.Contains(t.SizeValue)).ToListAsync();
            product.CategoryId = categoryId;

            await productRepository.AddProductAsync(product);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> SearchProduct(string productName)
        {
            return View("Product", await productRepository.GetProductByNameAsync(productName));
        }

        public async Task<IActionResult> HideProduct(int productId)
        {
            await productRepository.HideProductAsync(productId);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> ShowProduct(int productId)
        {
            await productRepository.ShowProductAsync(productId);
            return RedirectToAction("Product");
        }

        private async Task<List<Photo>> AddPhotosToProduct(IFormFileCollection photos)
        {
            List<Photo> savePhoto = new List<Photo>();
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
                savePhoto.Add(photo);

                SqueezePhoto(p);
            }
            return savePhoto;
        }

        private void SqueezePhoto(IFormFile photo)
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

        private void DeletePhoto(string photoName)
        {
            FileInfo photoMedium = new FileInfo(webHostEnvironment.WebRootPath + "/img/products-photo/medium/" + photoName);
            FileInfo photoLarge = new FileInfo(webHostEnvironment.WebRootPath + "/img/products-photo/large/" + photoName);
            photoMedium.Delete();
            photoLarge.Delete();
        }
    }
}
