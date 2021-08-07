using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productsRepository;
        private ICategoryRepository categoryRepository;
        private IWhishlistrepository whishlistrepository;
        private ISizeRepository sizeRepository;

        private const int productPerPage = 8;

        public ProductController(IProductRepository pr, ICategoryRepository categoryRepository, IWhishlistrepository whishlistrepository, ISizeRepository sizeRepository)
        {
            productsRepository = pr;
            this.categoryRepository = categoryRepository;
            this.whishlistrepository = whishlistrepository;
            this.sizeRepository = sizeRepository;
        }

        public async Task<IActionResult> List(FiltrModel filtr, string categoryName = " ", int productPage = 1)
        {
            Category category = categoryRepository.GetCategoryByName(categoryName);
            ViewBag.selecteCategory = category?.LatinName;
             
            ProductListViewModel model = new ProductListViewModel
            {
                ProductsInfo = await FiltrProductsAsync(filtr, category?.Id, productPage),
                Category = category?.Name ?? "Новинки",
            };

            if (filtr.isAjax)
                return PartialView("Partial/ProductPartial", model.ProductsInfo);
            else  
                return View(model);
        }

        public async Task<IActionResult> Product(string categoryName, string productName, int productId)
        {
            Random r = new Random();
            int quantityOfRecomendedProducts = 6;
            Product product = await productsRepository.Products.Include(t => t.Photos).Include(t => t.Sizes).Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == productId);
            List<Product> recomendedProducts = await productsRepository.Products?.Where(t => t.CategoryId == product.CategoryId && t.Id != product.Id).OrderBy(t => Guid.NewGuid()).Take(quantityOfRecomendedProducts).Include(t => t.Photos).ToListAsync();
            return View(new ProductViewModel { 
                Product = product,
                RecomendedProducts = recomendedProducts
            });
        }

        private async Task<ProductsInfo> FiltrProductsAsync(FiltrModel filtr, int? categoryId, int productPage)
        {
            string[] colors = filtr?.Colors?.Split(new char[] { '_' });
            string[] sizes = filtr?.Sizes?.Split(new char[] { '_' });
            int minPrice = filtr.Price == null ? 0 : int.Parse(filtr?.Price?.Split(new char[] { '-' })[0]);
            int maxPrice = filtr.Price == null ? 0 : int.Parse(filtr?.Price?.Split(new char[] { '-' })[1]);

            List<Product> filteredProducts = await productsRepository.Products.Include(t => t.Photos).Include(t => t.Category)
                .Where(t => t.IsSeen == true && (categoryId == null || t.CategoryId == categoryId) &&
                (colors == null || colors.Contains(t.Color)) &&
                (sizes == null || t.Sizes.Any(s => sizes.Contains(s.SizeValue.ToString()))) &&
                (filtr.Price == null || (t.Price >= minPrice && t.Price <= maxPrice))).ToListAsync();

            return new ProductsInfo()
            {
                Products = filteredProducts.Skip((productPage - 1) * productPerPage).Take(productPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ProductPerPage = productPerPage,
                    SumProduct = filteredProducts.Count()
                },
                FiltrInfo = new FiltrInfo
                {
                    MinPrice = await GetMinPriceAsync(categoryId),
                    MaxPrice = await GetMaxPriceAsync(categoryId),
                    Sizes = await GetSizesAsync(categoryId),
                    Colors = await GetColorsAsync(categoryId)
                },
                WishlistProductsId = await GetWishlistProductsAsync()
            };
        }

        public async Task<List<int>> GetWishlistProductsAsync()
        {
            string wishlistId = HttpContext.Request.Cookies["wishlist_id"];
            List<Product> wishlistProducts = await whishlistrepository.Wishlists.Where(t => t.Id == wishlistId).Select(t => t.Products).FirstOrDefaultAsync();
            return wishlistProducts?.Select(t => t.Id).ToList();
        }

        public async Task<List<int>> GetSizesAsync(int? categoryId)
        {
            return await sizeRepository.Sizes
                .Where(t => t.Products.Any(p => categoryId == null || p.CategoryId == categoryId))
                .Distinct().Select(t => t.SizeValue).ToListAsync();
        }

        public async Task<List<string>> GetColorsAsync(int? categoryId)
        {
            return await productsRepository.Products.Where(p => categoryId == null || p.CategoryId == categoryId)
                .Select(p => p.Color).Distinct().ToListAsync();
        }

        public async Task<int?> GetMinPriceAsync(int? categoryId)
        {
            if(productsRepository.Products.Count() !=0)
                return await productsRepository?.Products?.Where(t => categoryId == null || t.CategoryId == categoryId).MinAsync(t => t.Price);
            return 0;
        }

        public async Task<int?> GetMaxPriceAsync(int? categoryId)
        {
            if (productsRepository.Products.Count() != 0)
                return await productsRepository?.Products?.Where(t => categoryId == null || t.CategoryId == categoryId).MaxAsync(t => t.Price);
            return 0;
        }
    }
}
