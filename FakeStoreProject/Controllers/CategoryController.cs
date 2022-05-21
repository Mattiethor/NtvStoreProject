using Microsoft.AspNetCore.Mvc;
using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;


namespace FakeStoreProject.Controllers
{
    [Route("api/categories")]
    [Controller]
    public class CategoryController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public CategoryController(IRepository repository)
        {
            _repository = repository;
        }


        
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
        {
            try
            {


                List<Category> product = await _repository.GetAllCategoriesAsync();
                return Ok(product);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetCategoryByIdAsync(int id)
        {

            try
            {
                //ASK about why i don't get 404
                Category category = await _repository.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(category);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        //Create category
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody]Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCategoryAsync(category);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetCategoryByIdAsync), new { category.Id }, category);
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

    }

}
