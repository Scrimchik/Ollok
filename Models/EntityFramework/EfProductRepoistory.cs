using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    public class EfProductRepoistory : IProductRepository
    {
        private ApplicationDbContext db;

        public EfProductRepoistory(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Product> Products => db.Products.Include(t => t.Category).Include(t => t.Photos).Include(t => t.Sizes);

        public async Task<Product> GetProductAsync(int id)
        {
            return await db.Products.Where(t => t.Id == id).Include(t => t.Category).Include(t => t.Photos)
                .Include(t => t.Sizes).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            return await db.Products.Where(t => t.Name.Contains(productName)).Include(t => t.Category).Include(t => t.Photos)
                .Include(t => t.Sizes).FirstOrDefaultAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            Product unUpdatedProduct = await db.Products.FindAsync(product.Id);
            unUpdatedProduct.Name = product.Name;
            unUpdatedProduct.LatinName = product.LatinName;
            unUpdatedProduct.Price = product.Price;
            unUpdatedProduct.Sizes = product.Sizes;
            unUpdatedProduct.Photos.AddRange(product.Photos);
            unUpdatedProduct.Color = product.Color;
            await db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task ShowProductAsync(int productId)
        {
            Product product = await db.Products.FindAsync(productId);
            product.IsSeen = true;
            await db.SaveChangesAsync();
        }

        public async Task HideProductAsync(int productId)
        {
            Product product = await db.Products.FindAsync(productId);
            product.IsSeen = false;
            await db.SaveChangesAsync();
        }

        public async Task AddLikeToProductAsync(Product product)
        {
            product.Like++;
            await db.SaveChangesAsync();
        }

        public async Task RemoveLikeFromProductAsync(Product product)
        {
            product.Like--;
            await db.SaveChangesAsync();
        }
    }
}
