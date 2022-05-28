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
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
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

        //Delete Category 
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Category>> DeleteCategoryAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteCategoryAsync(id);
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

        //UPDATE SECTION
        [HttpPut]
        [Route("{id}")]
        //Put id before FromBody, the id does not get updated.
        public async Task<ActionResult<Category>> UpdateCategoryAsync(int id, [FromBody] Category category)
        {
            try
            {
                Category categoryToUpdate = await _repository.UpdateCategoryAsync(id, category);
                if (categoryToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCategoryByIdAsync), new { categoryToUpdate.Id }, category);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }

}
