
using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;
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


        //Get to get all Products async.
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllItemsAsync()
        {
            try
            {
                List<Product> product = await _repository.GetAllProductsAsync();
                return Ok(product);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        //Get to get  Products by id async.

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {

            try
            {

                ProductDTO prod = await _repository.GetProductByIdAsync(id);
                if (prod == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(prod);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
    
