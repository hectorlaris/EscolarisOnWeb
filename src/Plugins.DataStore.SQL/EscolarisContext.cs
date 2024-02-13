using Microsoft.EntityFrameworkCore;
using CoreBusiness;
using System;

namespace Plugins.DataStore.SQL
{
    public class EscolarisContext : DbContext
    {
        public EscolarisContext(DbContextOptions<EscolarisContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AcadProgram> AcadPrograms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.AcadPrograms)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Pregrado", Description = "Pregrado" },
                    new Category { CategoryId = 2, Name = "Postgrado", Description = "Postgrado" },
                    new Category { CategoryId = 3, Name = "Educación Continúa", Description = "Educación Continúa" }

                );

            modelBuilder.Entity<AcadProgram>().HasData(
                    new AcadProgram { ProgramId = 1, CategoryId = 1, Name = "System Engineering", Quantity = 30, Price = 17.99 },
                    new AcadProgram { ProgramId = 2, CategoryId = 1, Name = "Mathematic", Quantity = 20, Price = 8.99 },
                    new AcadProgram { ProgramId = 3, CategoryId = 2, Name = "Specilization in Biology", Quantity = 25, Price = 12.50 },
                    new AcadProgram { ProgramId = 4, CategoryId = 2, Name = "Master in Education", Quantity = 32, Price = 5.50 }
                );
        }
    }
}

