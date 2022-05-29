using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace FakeStoreProject.Controllers
{
    [Route("api/Orders")]
    [Controller]
    public class OrderController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public OrderController(IRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrdersAsync()
        {
            try
            {


                List<Order> orders = await _repository.GetAllOrdersAsync();
                return Ok(orders);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {

            try
            {
                
                Order order = await _repository.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(order);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        //Create category
        
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateOrderAsync(order);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetOrderByIdAsync), new { order.Id }, order);
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
        public async Task<ActionResult<Order>> DeleteOrderAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteOrderAsync(id);
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
        public async Task<ActionResult<Order>> UpdateOrderAsync(int id, [FromBody] Order order)
        {
            try
            {
                Order orderToUpdate = await _repository.UpdateOrderAsync(id, order);
                if (orderToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetOrderByIdAsync), new { orderToUpdate.Id }, order);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }

}
