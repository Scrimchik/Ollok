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

        public WishlistController(IWhishlistrepository whishlistrepository, IProductRepository productRepository)
        {
            this.whishlistrepository = whishlistrepository;
            productsRepository = productRepository;
        }

        public async Task<IActionResult> AddProductToWishList(int productId)
        {
            string wishListId = HttpContext.Request.Cookies["wishlist_id"] ?? null;
            Product product = await productsRepository.GetProductAsync(productId);

            if (wishListId == null)
            {
                Wishlist newWishList = new Wishlist { Id = Guid.NewGuid().ToString() };
                HttpContext.Response.Cookies.Append("wishlist_id", newWishList.Id);
                newWishList.Products.Add(product);
                await productsRepository.AddLikeToProductAsync(product);
                await whishlistrepository.AddWishlistAsync(newWishList);
            }
            else
            {
                Wishlist wishList = await whishlistrepository.Wishlists.Include(t => t.Products).FirstOrDefaultAsync(t => t.Id == wishListId);
                if(wishList.Products.Any(t => t.Id == productId)) {
                    await productsRepository.RemoveLikeFromProductAsync(product);
                    wishList.Products.Remove(product);
                }
                else {
                    await productsRepository.AddLikeToProductAsync(product);
                    wishList.Products.Add(product);
                }
                await whishlistrepository.UpdateWishlistAsync(wishList);
            }

            return StatusCode(200);
        }

        public IActionResult GetWishlist()
        {
            return ViewComponent("Wishlist");
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            string wishlistId = HttpContext.Request.Cookies["wishlist_id"];
            Product removedProduct = await productsRepository.GetProductAsync(productId);
            Wishlist wishList = await whishlistrepository.Wishlists.Include(t => t.Products).FirstOrDefaultAsync(t => t.Id == wishlistId);

            await productsRepository.RemoveLikeFromProductAsync(removedProduct);
            wishList.Products.Remove(removedProduct);
            await whishlistrepository.UpdateWishlistAsync(wishList);
            return RedirectToAction("List", "Product");
        }

        public async Task<int> CheckWishlistCount()
        {
            string wishlistId = HttpContext.Request.Cookies["wishlist_id"];
            return await productsRepository.Products.Where(t => t.Wishlists.Any(w => w.Id == wishlistId)).CountAsync();
        }
    }
}
