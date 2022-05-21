using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;

namespace FakeStoreProject.Data.Interfaces
{
    public interface IRepository
    {
        //TODO making Products async
        Task<List<Product>> GetAllProductsAsync();

         Task<ProductDTO> GetProductByIdAsync(int id);



        //Task<Category> GetCategoryByIdAsync(int id);
    }
}
