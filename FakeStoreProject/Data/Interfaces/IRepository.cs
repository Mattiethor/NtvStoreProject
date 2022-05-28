using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;

namespace FakeStoreProject.Data.Interfaces
{
    public interface IRepository
    {

        //Products
        Task<List<Product>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product product);

        Task<bool> DeleteProductAsync(int id);

        Task CreateProductAsync(Product product);

        //Category

        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);

        Task<Category> UpdateCategoryAsync(int id, Category category);

        //Stock

        Task<List<Stock>> GetAllStocksAsync();

        Task<Stock> GetStockByIdAsync(int id);



    }
}
