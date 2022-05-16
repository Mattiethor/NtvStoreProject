using FakeStoreProject.Models;

namespace FakeStoreProject.Data.Interfaces
{
    public interface IRepository
    {
        List<Product> GetAllProducts ();

        Product GetProductById (int id);


    }
}
