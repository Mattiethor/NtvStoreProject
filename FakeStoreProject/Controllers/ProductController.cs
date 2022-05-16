
using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace FakeStoreProject.Controllers
{
    [Route("api/products")]
    [Controller]
    public class ProductController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public ProductController(IRepository repository)
        {
            _repository = repository;
        }


        //TODO add a DTO to remove itemOrders from the GET
        [HttpGet]
        public ActionResult<List<Product>> GetAllItems()
        {
            try
            {
                List<Product> product = _repository.GetAllProducts();
                return product;

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }



    }
}
