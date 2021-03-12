using FluentApiLesson.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Data
{
    public class FluentContext : DbContext
    {
        public FluentContext()
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = FluentApiLessonHW; Trusted_connection = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Product>()
            .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(50);



            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(product => product.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            modelBuilder.Entity<Dish>()
                .HasMany(dishes => dishes.Products)
                .WithMany(product => product.Dishes);

            //modelBuilder.Entity<Product>()
            //    .HasMany(product => product.Dishes)
            //    .WithMany(dishes => dishes.Products);

            base.OnModelCreating(modelBuilder);
        }

    }
}
