using FakeStoreProject.Models;

namespace FakeStoreProject.Data.Interfaces
{
    public class StoreRepository : IRepository
    {
        private FakeStoreDbContext _dbContext;

        public StoreRepository()
        {
            _dbContext = new FakeStoreDbContext();
        }



        public List<Product> GetAllProducts()
        {
            List<Product> products;
            using(var db = _dbContext)
            {
                products = db.Products.ToList();
            }
            return products;
            
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
