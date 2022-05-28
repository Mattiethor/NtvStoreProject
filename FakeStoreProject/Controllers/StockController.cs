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
    }

}
