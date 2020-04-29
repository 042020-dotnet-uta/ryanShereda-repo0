using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Models
{
    class BaB_DbContext : DbContext
    {


        public BaB_DbContext()
        {

        }

        public BaB_DbContext(DbContextOptions<BaB_DbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=BitsAndBobs.db");
            }
        }
    }
}
