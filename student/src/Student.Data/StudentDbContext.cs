using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = SharedLibs.Data;

namespace Student.Data
{
    public class StudentDbContext: DbContext
    {
        public DbSet<model.Student> Students { get; set; }
        
        public StudentDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<model.Student>()
                .HasKey(s => s.Id);
            
            modelBuilder.Entity<model.Student>()
                .HasIndex(s => s.Code)
                .IsUnique();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.Code)
                .IsRequired();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.FirstName)
                .IsRequired();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.LastName)
                .IsRequired();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.DateOfBirth)
                .IsRequired();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.Created)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<model.Student>()
                .Property(s => s.Updated)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
