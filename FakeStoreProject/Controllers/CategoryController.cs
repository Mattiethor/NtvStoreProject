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


        //TODO see if i can add a list of Products tied to this
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

    }

}
