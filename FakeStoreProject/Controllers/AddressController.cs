using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProject.Controllers
{
    [Route("api/addresses")]
    [Controller]
    public class AddressController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public AddressController(IRepository repository)
        {
            _repository = repository;
        }


        //Get to get all Addresses async.
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddressesAsync()
        {
            try
            {
                List<Address> address = await _repository.GetAllAddressesAsync();
                return Ok(address);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Address>> GetAddressByIdAsync(int id)
        {

            try
            {
                //ASK about why i don't get 404
                Address address = await _repository.GetAddressByIdAsync(id);
                if (address == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(address);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        //Create address
        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync([FromBody] Address address)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateAddressAsync(address);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetAddressByIdAsync), new { address.Id }, address);

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

        //Delete address 
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Address>> DeleteAddressAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteAddressAsync(id);
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

        //update address
        [HttpPut]
        [Route("{id}")]
        //Put id before FromBody, the id does not get updated.
        public async Task<ActionResult<Address>> UpdateAddressAsync(int id, [FromBody] Address address)
        {
            try
            {
                Address addressToUpdate = await _repository.UpdateAddressAsync(id, address);
                if (addressToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetAddressByIdAsync), new { addressToUpdate.Id }, address);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
