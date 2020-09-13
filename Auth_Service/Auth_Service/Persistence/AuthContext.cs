using Auth_Service.Domain.Models;
using Auth_Service.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Auth_Service.Persistence
{
    public class AuthContext:DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options):base(options)
        {

        }
        public DbSet<TblUser> TblUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TblUserConfiguration());

        }
    }
}
