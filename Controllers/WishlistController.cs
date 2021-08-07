using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Controllers
{
    public class WishlistController: Controller
    {
        private IWhishlistrepository whishlistrepository;
        private IProductRepository productsRepository;
        private ApplicationDbContext db;

        public WishlistController(IWhishlistrepository whishlistrepository, IProductRepository productRepository, ApplicationDbContext context)
        {
            this.whishlistrepository = whishlistrepository;
            productsRepository = productRepository;
            db = context;
        }

        public async Task<IActionResult> AddProductToWishList(int productId)
        {
            string wishListId = HttpContext.Request.Cookies["wishlist_id"] ?? null;
            Product likedProduct = await productsRepository.Products.FirstOrDefaultAsync(t => t.Id == productId);
            if (wishListId == null)
            {
                Wishlist newWishList = new Wishlist { Id = Guid.NewGuid().ToString() };
                HttpContext.Response.Cookies.Append("wishlist_id", newWishList.Id);
                likedProduct.Like++;
                newWishList.Products.Add(likedProduct);
                db.Wishlists.Add(newWishList);
            }
            else
            {
                Wishlist wishList = db.Wishlists.Include(t => t.Products).FirstOrDefault(t => t.Id == wishListId);
                if(wishList.Products.Any(t => t.Id == productId)) {
                    likedProduct.Like--;
                    wishList.Products.Remove(likedProduct);
                }
                else {
                    likedProduct.Like++;
                    wishList.Products.Add(likedProduct);
                }
            }
            await db.SaveChangesAsync();
            return StatusCode(200);
        }

        public async Task<IActionResult> GetWishlist()
        {
            return ViewComponent("Wishlist", await whishlistrepository.Wishlists.Where(t => t.Id == HttpContext.Request.Cookies["wishlist_id"])
                .Include(t => t.Products).ThenInclude(t => t.Photos)
                .Include(t => t.Products).ThenInclude(t => t.Category)
                .FirstOrDefaultAsync());
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            string wishlistId = HttpContext.Request.Cookies["wishlist_id"];
            Wishlist wishList = await whishlistrepository.Wishlists.Include(t => t.Products).FirstOrDefaultAsync(t => t.Id == wishlistId);
            Product unlikedProduct = await productsRepository.Products.FirstOrDefaultAsync(t => t.Id == productId);
            unlikedProduct.Like--;
            wishList.Products.Remove(unlikedProduct);
            await db.SaveChangesAsync();
            return RedirectToAction("List", "Product");
        }

        public async Task<int> CheckWishlistCount()
        {
            return await productsRepository.Products.Where(t => t.Wishlists.Any(w => w.Id == HttpContext.Request.Cookies["wishlist_id"])).CountAsync();
        }
    }
}
