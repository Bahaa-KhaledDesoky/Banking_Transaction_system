using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking_system.DataInstanse;
using Microsoft.EntityFrameworkCore;

namespace Banking_system.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {

        }
        public DbSet<AppUser> appUser{get;set;}
    }
}