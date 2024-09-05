using AutoMapper;
using Microsoft.EntityFrameworkCore;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Interfaces;
using stockz_bucketz_api.Models;
using stockz_bucketz_api.Services;
using System.Linq;

namespace stockz_bucketz_api.Context.Dao
{
    public class StockDao : IStockDao
    {
        private readonly AppDbContext _context;
        private readonly ApiBrapiService _brapiService;
        private IMapper _mapper;

        public StockDao(AppDbContext context, ApiBrapiService brapiService, IMapper mapper)
        {
            _context = context;
            _brapiService = brapiService;
            _mapper = mapper;
        }


        public async Task Add(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);
            var existingStock = await _context
                .Stocks
                .FirstOrDefaultAsync
                (s => s.Code == transaction.Code && s.PortfolioId == transaction.PortfolioId);

            if (existingStock != null)
            {
                var updatedStock = transaction.UpdateStock(existingStock);
                _context.Stocks.Update(updatedStock);
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                var newStock = transaction.AddNewStock(transaction.UnitPrice);
                _context.Stocks.Add(newStock);
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            await UpdateUnitPrice(transaction.PortfolioId);
        }
        public async Task<ICollection<Stock>> GetByUserId(string id)
        {
            return await _context.Stocks
                .Where(s => s.PortfolioId == id)
                .ToListAsync();
        }
        public async Task UpdateUnitPriceOfActions()
        {
            if (_context.SavesStocks.Count() == 0)
            {
                var allStocks = await _brapiService.Get();
                foreach ( var stock in allStocks)
                {
                    _context.StocksBrapi.Add(stock);
                    _context.SaveChanges();
                }
                var newSave = new SaveStocks();
                _context.SavesStocks.Add(newSave);
                await _context.SaveChangesAsync();
            }

            var lastSave = _context.SavesStocks.OrderByDescending(s => s.DateOfSave).FirstOrDefault().DateOfSave;
            var lastSaveAdd30 = lastSave.AddMinutes(30);
            if (lastSaveAdd30 <= DateTime.Now || lastSave==null)
            {
                var allStocks = await _brapiService.Get();
                var allStokcsBd = await _context.StocksBrapi.ToListAsync();
                foreach (var stock in allStocks)
                {
                    var stockBd = allStokcsBd.FirstOrDefault(s => s.Stock == stock.Stock);
                    if (stockBd==null)
                    {
                        _context.StocksBrapi.Add(stock);
                    }
                    else
                    {
                        stockBd.Close = stock.Close;
                    }
                }
                var newSave = new SaveStocks();
                _context.SavesStocks.Add(newSave);
                await _context.SaveChangesAsync();
            }
            
        }
        public async Task UpdateUnitPrice(string userId)
        {
            await UpdateUnitPriceOfActions();
            var allStocksOfUser = _context.Stocks.Where(u => u.PortfolioId == userId).ToList();
            var allStocks = await _context.StocksBrapi.ToListAsync();
            foreach (var stock in allStocksOfUser)
            {
                var stockPrice = allStocks.FirstOrDefault(c => c.Stock == stock.Code);
                stock.UnitPrice = stockPrice.Close;
                stock.Value = stock.UnitPrice * stock.Amount;

            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<StockBrapi>> GetAllStocks()
        {
            var stocks = await _context.StocksBrapi.ToListAsync();
            if(stocks.Count == 0) 
            {
                await UpdateUnitPriceOfActions();
            }
            stocks = await _context.StocksBrapi.ToListAsync();
            return stocks;
        }
        public async Task Delete(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}
