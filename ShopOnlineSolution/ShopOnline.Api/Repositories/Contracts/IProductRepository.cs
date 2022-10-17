using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<Product>> GetCategories();
        Task<IEnumerable<Product>> GetItem(int id);
        Task<IEnumerable<Product>> GetCatogory(int id);

    }
}
