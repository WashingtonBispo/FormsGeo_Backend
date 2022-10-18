using FormsGeo.Data.Mapping;
using FormsGeo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ec2-3-220-207-90.compute-1.amazonaws.com;Port=5432;Database=d82240nlscgru8;Username=rvwtmqbdvbibpc;Password=442686063704881238fcc07f075eac7375b89d011505ae8c91f16b6b72509f35");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
