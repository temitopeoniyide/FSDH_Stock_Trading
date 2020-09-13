using Auth_Service.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Domain
{
   public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; set; }
        int CommitChanges();
        Task<int> CommitChangesAsync();

    }
}
