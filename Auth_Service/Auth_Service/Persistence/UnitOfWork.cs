using Auth_Service.Domain;
using Auth_Service.Domain.IRepositories;
using Auth_Service.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        public IUserRepository Users { get; set; }

        private readonly AuthContext _context;

        public UnitOfWork(AuthContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
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
