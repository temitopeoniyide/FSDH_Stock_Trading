using Auth_Service.Domain.IRepositories;
using Auth_Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Persistence.Repositories
{
    public class UserRepository : Repository<TblUser>, IUserRepository
    {
        public UserRepository(AuthContext context) : base(context)
        {
        }



        public AuthContext DataContext { get { return Context as AuthContext; } }
    }
}
