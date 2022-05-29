using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace FakeStoreProject.Controllers
{
    [Route("api/ItemOrders")]
    [Controller]
    public class ItemOrderController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public ItemOrderController(IRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<List<ItemOrder>>> GetAllItemOrdersAsync()
        {
            try
            {


                List<ItemOrder> itemOrders = await _repository.GetAllItemOrdersAsync();
                return Ok(itemOrders);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemOrder>> GetItemOrderByIdAsync(int id)
        {

            try
            {
                //ASK about why i don't get 404
                ItemOrder itemOrder = await _repository.GetItemOrderByIdAsync(id);
                if (itemOrder == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(itemOrder);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        //Create category
        //See if i can add a link between CreateItem and stock. Stock decreases if a ItemOrder is created.
        [HttpPost]
        public async Task<IActionResult> CreateItemOrderAsync([FromBody] ItemOrder itemOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateItemOrderAsync(itemOrder);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetItemOrderByIdAsync), new { itemOrder.Id }, itemOrder);
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
        public async Task<ActionResult<ItemOrder>> DeleteItemOrderAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteItemOrderAsync(id);
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
        public async Task<ActionResult<ItemOrder>> UpdateItemOrderAsync(int id, [FromBody] ItemOrder itemOrder)
        {
            try
            {
                ItemOrder itemOrderToUpdate = await _repository.UpdateItemOrderAsync(id, itemOrder);
                if (itemOrderToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetItemOrderByIdAsync), new { itemOrderToUpdate.Id }, itemOrder);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }

}