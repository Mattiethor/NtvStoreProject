using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;
using Microsoft.AspNetCore.Mvc;


namespace FakeStoreProject.Controllers
{
    [Route("api/staff")]
    [Controller]
    public class StaffController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public StaffController(IRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetAllStaffAsync()
        {
            try
            {


                List<Staff> staff = await _repository.GetAllStaffAsync();
                return Ok(staff);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Staff>> GetStaffByIdAsync(int id)
        {

            try
            {
                //ASK about why i don't get 404
                Staff staff = await _repository.GetStaffByIdAsync(id);
                if (staff == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(staff);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        //Create category
        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync([FromBody] Staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateStaffAsync(staff);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetStaffByIdAsync), new { staff.Id }, staff);
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
        public async Task<ActionResult<Staff>> DeleteStaffAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteStaffAsync(id);
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
        public async Task<ActionResult<Staff>> UpdateStaffAsync(int id, [FromBody] Staff staff)
        {
            try
            {
                Staff staffToUpdate = await _repository.UpdateStaffAsync(id, staff);
                if (staffToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetStaffByIdAsync), new { staffToUpdate.Id }, staff);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }

}
