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

        Task CreateStockAsync(Stock stock);

        Task<bool> DeleteStockAsync(int id);

        Task<Stock> UpdateStockAsync(int id, Stock stock);

        //Store

        Task<List<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(int id);

        Task CreateStoreAsync(Store store);

        Task<bool> DeleteStoreAsync(int id);

        Task<Store> UpdateStoreAsync(int id, Store store);

        //Address 
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);

        Task CreateAddressAsync(Address address);

        Task<bool> DeleteAddressAsync(int id);

        Task<Address> UpdateAddressAsync(int id, Address address);

        //Staff
        Task<List<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);

        Task CreateStaffAsync(Staff staff);

        Task<bool> DeleteStaffAsync(int id);

        Task<Staff> UpdateStaffAsync(int id, Staff staff);

        //Customer
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);

        Task CreateCustomerAsync(Customer customer);

        Task<bool> DeleteCustomerAsync(int id);

        Task<Customer> UpdateCustomerAsync(int id, Customer customer);

        //ItemOrder
        Task<List<ItemOrder>> GetAllItemOrdersAsync();
        Task<ItemOrder> GetItemOrderByIdAsync(int id);

        Task CreateItemOrderAsync(ItemOrder itemOrder);

        Task<bool> DeleteItemOrderAsync(int id);

        Task<ItemOrder> UpdateItemOrderAsync(int id, ItemOrder itemOrder);

    }
}
