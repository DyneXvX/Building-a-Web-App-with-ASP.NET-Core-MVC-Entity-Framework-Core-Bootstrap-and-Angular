using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DutchTreat.Data
{
    public class DutchContext : DbContext //a class that knows how to do queues to a data core
    {
        public DutchContext(DbContextOptions<DutchContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        //only create Db sets for things you want to query against.

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasData(new Order()
                    {
                        Id = 1,
                        OrderDate = DateTime.UtcNow,
                        OrderNumber = "12345"
                    }
                );
        }
        //this is great for adding a simple line of data. See seedata.cs for information.
    }
}
