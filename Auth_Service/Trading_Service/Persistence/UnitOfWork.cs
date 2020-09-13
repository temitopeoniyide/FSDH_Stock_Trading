using Trading_Service.Domain;
using Trading_Service.Domain.IRepositories;
using Trading_Service.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        public IStockCompanyRepository StockCompanies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IStocksRepository Stocks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPurchaseRepository Purchase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly StockContext _context;

        public UnitOfWork(StockContext context)
        {
            _context = context;
            StockCompanies = new StockCompanyRepository(_context);
            Stocks = new StockRepository(_context);
            Purchase = new PurchaseRepository(_context);

        }
        public async Task<int> CommitChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

            //throw new NotImplementedException();
        }
    }
}
