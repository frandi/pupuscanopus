using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Classroom.Data;

namespace Classroom.Data.Migrations
{
    [DbContext(typeof(ClassroomDbContext))]
    [Migration("20161231100058_AddClassroomDb")]
    partial class AddClassroomDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SharedLibs.Data.Classroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SchoolId");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("SharedLibs.Data.ClassroomStudent", b =>
                {
                    b.Property<Guid>("ClassroomId");

                    b.Property<Guid>("StudentId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("StudentCode");

                    b.Property<string>("StudentFirstName");

                    b.Property<string>("StudentLastName");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("ClassroomId", "StudentId");

                    b.ToTable("ClassroomStudents");
                });

            modelBuilder.Entity("SharedLibs.Data.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("SharedLibs.Data.Classroom", b =>
                {
                    b.HasOne("SharedLibs.Data.School", "School")
                        .WithMany("Classrooms")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SharedLibs.Data.ClassroomStudent", b =>
                {
                    b.HasOne("SharedLibs.Data.Classroom", "Classroom")
                        .WithMany("ClassroomStudents")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
