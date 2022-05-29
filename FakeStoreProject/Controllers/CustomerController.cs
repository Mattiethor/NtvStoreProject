using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace FakeStoreProject.Controllers
{
    [Route("api/customers")]
    [Controller]
    public class CustomerController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomersAsync()
        {
            try
            {


                List<Customer> customers = await _repository.GetAllCustomersAsync();
                return Ok(customers);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(int id)
        {

            try
            {
                
                Customer customer = await _repository.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        //Create 
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCustomerAsync(customer);
                    
                    return CreatedAtAction(nameof(GetCustomerByIdAsync), new { customer.Id }, customer);
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

        //Delete  
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteCustomerAsync(id);
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

        //UPDATE 
        [HttpPut]
        [Route("{id}")]
        //Put id before FromBody, the id does not get updated.
        public async Task<ActionResult<Customer>> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer customerToUpdate = await _repository.UpdateCustomerAsync(id, customer);
                if (customerToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCustomerByIdAsync), new { customerToUpdate.Id }, customer);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }

}