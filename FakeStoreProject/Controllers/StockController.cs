using FakeStoreProject.Data.Interfaces;
using FakeStoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreProject.Controllers
{
    [Route("api/stocks")]
    [Controller]

    public class StockController : ControllerBase
    {
        private IRepository _repository;

        //Used to access the database
        public StockController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllStocksAsync()
        {
            try
            {
                List<Stock> stock = await _repository.GetAllStocksAsync();
                return Ok(stock);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Stock>> GetStockByIdAsync(int id)
        {

            try
            {

                Stock stock = await _repository.GetStockByIdAsync(id);
                if (stock == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(stock);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateStockAsync([FromBody] Stock stock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateStockAsync(stock);
                    //ASK TEACHER ABOUT THIS
                    return CreatedAtAction(nameof(GetStockByIdAsync), new { stock.Id }, stock);
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
        public async Task<ActionResult<Stock>> DeleteStockAsync(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteStockAsync(id);
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
        public async Task<ActionResult<Stock>> UpdateStockAsync(int id, [FromBody] Stock stock)
        {
            try
            {
                Stock stockToUpdate = await _repository.UpdateStockAsync(id, stock);
                if (stockToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetStockByIdAsync), new { stockToUpdate.Id }, stock);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }

}
