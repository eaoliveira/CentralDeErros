﻿using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Context
{
    
    public class CentralContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Infra.Entidades.Environment> Environments { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=centraldeerros.database.windows.net;Database=CentralDeErros;User Id=ADM;Password=Squad@03;Trusted_Connection=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Users>().HasMany(u => u.ErrorOccurrences).WithOne(u => u.User).IsRequired();
            //modelBuilder.Entity<Situation>().HasMany(s => s.ErrorOccurrences).WithOne(s => (Situation)s.Situation).IsRequired();
            modelBuilder.Entity<Level>().HasMany(l => l.Errors).WithOne(l => l.Level).IsRequired();
            modelBuilder.Entity<Infra.Entidades.Environment>().HasMany(e => e.Errors).WithOne(e => e.Environment).IsRequired();
            modelBuilder.Entity<Error>().HasKey(e => e.ErrorId);
            modelBuilder.Entity<Logs>().HasKey(e => e.ErrorOccurrenceId);
        }
    }

}
