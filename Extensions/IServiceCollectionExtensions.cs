using Microsoft.Extensions.DependencyInjection;
using Ollok.Models.Abstract;
using Ollok.Models.EntityFramework;

namespace Ollok.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDbEntities(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, EfProductRepoistory>();
            services.AddTransient<ICategoryRepository, EfCategoryRepository>();
            services.AddTransient<IWhishlistrepository, EfWishlistRepository>();
            services.AddTransient<ICartRepository, EfCartRepository>();
            services.AddTransient<ISizeRepository, EfSizeRepository>();
            services.AddTransient<ICartLineRepository, EfCartLineRepository>();
            services.AddTransient<IOrderRepository, EfOrderRepository>();
            services.AddTransient<IPhotoRepository, EfPhotoRepository>();
        }
    }
}
