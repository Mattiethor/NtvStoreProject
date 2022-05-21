using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace FakeStoreProject.Data.Interfaces
{
    public class StoreRepository : IRepository
    {
        private FakeStoreDbContext _dbContext;

        public StoreRepository()
        {
            _dbContext = new FakeStoreDbContext();
        }



        public async Task <List<Product>> GetAllProductsAsync()
        {
            List<Product> products;
            using(var db = _dbContext)
            {
                products = await db.Products.ToListAsync();
            }
            return products;
            


        }
        //Ask teacher about getting Category name
        public async Task <ProductDTO> GetProductByIdAsync(int id)
        {
            Product product;
            using var db = _dbContext;
            {
                product = await db.Products.FirstOrDefaultAsync(c => c.Id == id);
            }
            
            ProductDTO prodToReturn = new ProductDTO();

            prodToReturn.Id = product.Id;
            prodToReturn.Name = product.Name;
            prodToReturn.ListPrice = product.ListPrice;
            prodToReturn.ImgUrl = product.ImgUrl;
            prodToReturn.Description = product.Description;
            prodToReturn.CategoryId = product.CategoryId;
            prodToReturn.StockId = product.StockId;
            prodToReturn.ModelYear = product.ModelYear;
            
            return prodToReturn;
            

        }
    }
}
