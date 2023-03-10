﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Persistence.UniversityDb;

#nullable disable

namespace University.Persistence.UniversityDb.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20221115153924_AddRecordBookMigration")]
    partial class AddRecordBookMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("University.Core.Domain.RecordBooks.Models.RecordBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RecordBooks");
                });

            modelBuilder.Entity("University.Core.Domain.RecordBooks.Models.RecordBookSubject", b =>
                {
                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("RecordId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("RecordBooksSubjects");
                });

            modelBuilder.Entity("University.Core.Domain.Students.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RecordBookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecordBookId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("University.Core.Domain.Subjects.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("University.Core.Domain.Teachers.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("University.Core.Domain.Teachers.Models.TeacherSubject", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeacherId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TeachersSubjects");
                });

            modelBuilder.Entity("University.Core.Domain.RecordBooks.Models.RecordBookSubject", b =>
                {
                    b.HasOne("University.Core.Domain.RecordBooks.Models.RecordBook", null)
                        .WithMany("Subjects")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("University.Core.Domain.Subjects.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("University.Core.Domain.Students.Models.Student", b =>
                {
                    b.HasOne("University.Core.Domain.RecordBooks.Models.RecordBook", "RecordBook")
                        .WithMany()
                        .HasForeignKey("RecordBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecordBook");
                });

            modelBuilder.Entity("University.Core.Domain.Teachers.Models.TeacherSubject", b =>
                {
                    b.HasOne("University.Core.Domain.Subjects.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Core.Domain.Teachers.Models.Teacher", null)
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("University.Core.Domain.RecordBooks.Models.RecordBook", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("University.Core.Domain.Teachers.Models.Teacher", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
