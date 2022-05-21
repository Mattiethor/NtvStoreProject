
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
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
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



        //Create product
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateProductAsync(product);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetProductByIdAsync), new { product.Id }, product);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        //Delete product 
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Product>> DeleteProductAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteProductAsync(id);
                if (!deleteSuccessful)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


    }
}
    
