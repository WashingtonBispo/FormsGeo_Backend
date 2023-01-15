﻿using FormsGeo.Data.Mapping;
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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Big_Hurricane81");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<FormEntity>(new FormMap().Configure);
            modelBuilder.Entity<AnswerEntity>(new AnswerMap().Configure);
            modelBuilder.Entity<LocalEntity>(new LocalMap().Configure);
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<FormEntity> Form { get; set; }
        public DbSet<AnswerEntity> Answer { get; set; }
        public DbSet<LocalEntity> Local { get; set; }
    }
}
