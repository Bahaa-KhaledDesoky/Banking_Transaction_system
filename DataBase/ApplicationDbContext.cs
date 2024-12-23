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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany( u=>u.receive )
                .WithOne(t => t.receiver)
                .HasForeignKey(t => t.receiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AppUser>()
            .HasMany(u => u.send)
            .WithOne(t => t.sender)
            .HasForeignKey(t => t.senderId)
            .OnDelete(DeleteBehavior.Restrict) ;
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> appUser{get;set;}
        public DbSet<Transaction> transaction { get; set; }
    }
}