using Microsoft.AspNetCore.Mvc;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Interfaces;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController:ControllerBase
    {
        public IPortfolioDao _portfolioDao;
        public IStockDao _stockDao;
        public IMonthlyRecordDao _monthlyRecordDao;

        public PortfolioController(IPortfolioDao portfolioDao, IStockDao stockDao, IMonthlyRecordDao monthlyRecordDao)
        {
            _portfolioDao = portfolioDao;
            _stockDao = stockDao;
            _monthlyRecordDao = monthlyRecordDao;
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioDto dto)
        {
            await _portfolioDao.Create(dto);
            return Created();
        }
        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock(CreateTransactionDto dto)
        {
            await _stockDao.Add(dto);

            return Created();  
        }

        [HttpPost("AddMonthlyRecord")]
        public async Task<IActionResult> CreateMonthlyRecord(CreateMonthlyRecordWithDate create)
        {
            var dto = create.GenerateMonthlyRecord();
            await _monthlyRecordDao.Create(dto);
            return NoContent();
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> ReadPortfolio([FromQuery]string userId)
        {
            var portfolio= await _portfolioDao.GetByUserId(userId);
            return Ok(portfolio);
        }
        [HttpGet("AllStocks")]
        public async Task<IActionResult> ReadAllStocksB3()
        {
            return Ok(await _stockDao.GetAllStocks());
        }
    }
}
