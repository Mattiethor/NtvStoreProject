using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProject.Controllers
{
    [Route("api/stores")]
    [Controller]
    public class StoreController : ControllerBase
    {

        private IRepository _repository;

        //Used to access the database
        public StoreController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetAllStoresAsync()
        {
            try
            {
                List<Store> store = await _repository.GetAllStoresAsync();
                return Ok(store);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Store>> GetStoreByIdAsync(int id)
        {

            try
            {

                Store store = await _repository.GetStoreByIdAsync(id);
                if (store == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(store);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateStoreAsync([FromBody] Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateStoreAsync(store);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetStoreByIdAsync), new { store.Id }, store);
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Store>> DeleteStoreAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteStoreAsync(id);
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

        //update 
        [HttpPut]
        [Route("{id}")]
        //Put id before FromBody, the id does not get updated.
        public async Task<ActionResult<Stock>> UpdateStoreAsync(int id, [FromBody] Store store)
        {
            try
            {
                Store storeToUpdate = await _repository.UpdateStoreAsync(id, store);
                if (storeToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetStoreByIdAsync), new { storeToUpdate.Id }, store);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }





    }
}
