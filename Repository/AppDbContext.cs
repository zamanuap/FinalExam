using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Pocos;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerPoco> Customers { get; set; }
        public DbSet<CarPoco> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string _connStr = root.GetSection("ConnectionStrings").GetSection("EmployeeDBConnection").Value;
            optionsBuilder.UseSqlServer(_connStr);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPoco>(entry =>
                            entry.HasOne(c => c.Cars)
                                .WithMany(car => car.Customers)
                                .HasForeignKey(c => c.CarId)
                                 );

        }
    }
}
