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
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ec2-3-220-207-90.compute-1.amazonaws.com;Port=5432;Database=d82240nlscgru8;Username=rvwtmqbdvbibpc;Password=442686063704881238fcc07f075eac7375b89d011505ae8c91f16b6b72509f35");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<FormEntity>(new FormMap().Configure);
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<FormEntity> Form { get; set; }
    }
}
