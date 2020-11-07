using catalina.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.Repositories
{
    public class catalinaDBContext : DbContext
    {
        public catalinaDBContext()
        {

        }

        public catalinaDBContext(DbContextOptions<catalinaDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationConstants.DBCONNECTION);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
