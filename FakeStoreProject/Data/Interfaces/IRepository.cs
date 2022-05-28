using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;

namespace FakeStoreProject.Data.Interfaces
{
    public interface IRepository
    {
        //TODO making Products async
        Task<List<Product>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(Category category);

        Task CreateProductAsync(Product product);

        Task<bool> DeleteProductAsync(int id);

        Task<bool> DeleteCategoryAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product product);




        
    }
}
