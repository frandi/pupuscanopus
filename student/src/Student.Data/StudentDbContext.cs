using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Data
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        public StudentDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Code)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .Property(s => s.Created)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                .Property(s => s.Updated)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
