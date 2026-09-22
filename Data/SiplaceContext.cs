using System;
using Microsoft.EntityFrameworkCore;
using SiplaceApp.Models;

namespace SiplaceApp.Data
{
    public class SiplaceContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<SetupDetail> SetupDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SIPLACE;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SetupDetail>()
                .HasOne(sd => sd.Recipe)
                .WithMany(r => r.SetupDetails)
                .HasForeignKey(sd => sd.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
