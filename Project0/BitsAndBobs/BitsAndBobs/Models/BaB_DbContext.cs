using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BitsAndBobs.Models
{
    public class BaB_DbContext : DbContext
    {
        #region Constructors
        public BaB_DbContext()
        {

        }

        public BaB_DbContext(DbContextOptions<BaB_DbContext> options) : base(options)
        {

        }
        #endregion

        #region Database Set Declarations
        public DbSet<Product> ProductsDB { get; set; }
        public DbSet<Customer> CustomersDB { get; set; }
        public DbSet<OrderLineItem> OrderLineItemsDB { get; set; }
        public DbSet<Order> OrdersDB { get; set; }
        public DbSet<Location> LocationsDB { get; set; }
        public DbSet<Inventory> InventoryDB { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=BitsAndBobs.db"); //Set database file
            }
        }
    }
}
