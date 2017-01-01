using Microsoft.EntityFrameworkCore;
using model = SharedLibs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Data
{
    public class ClassroomDbContext: DbContext
    {
        public DbSet<model.Classroom> Classrooms { get; set; }
        public DbSet<model.ClassroomStudent> ClassroomStudents { get; set; }
        public DbSet<model.School> Schools { get; set; }

        public ClassroomDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Classroom configs
            modelBuilder.Entity<model.Classroom>()
                    .HasKey(c => c.Id);

            modelBuilder.Entity<model.Classroom>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<model.Classroom>()
                .HasOne(c => c.School)
                .WithMany(s => s.Classrooms)
                .HasForeignKey(c => c.SchoolId);

            modelBuilder.Entity<model.Classroom>()
                .Property(c => c.Created)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<model.Classroom>()
                .Property(c => c.Updated)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();
            #endregion

            #region ClassroomStudent configs
            modelBuilder.Entity<model.ClassroomStudent>()
                    .HasKey(cs => new { cs.ClassroomId, cs.StudentId });

            modelBuilder.Entity<model.ClassroomStudent>()
                .HasOne(cs => cs.Classroom)
                .WithMany(c => c.ClassroomStudents)
                .HasForeignKey(cs => cs.ClassroomId);

            modelBuilder.Entity<model.ClassroomStudent>()
                .Property(cs => cs.StudentId)
                .IsRequired();

            modelBuilder.Entity<model.ClassroomStudent>()
                .Property(cs => cs.Created)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<model.ClassroomStudent>()
                .Property(cs => cs.Updated)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate(); 
            #endregion

            #region School configs
            modelBuilder.Entity<model.School>()
                        .HasKey(s => s.Id);

            modelBuilder.Entity<model.School>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<model.School>()
                .Property(s => s.Created)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<model.School>()
                .Property(s => s.Updated)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate(); 
            #endregion
        }
    }
}
