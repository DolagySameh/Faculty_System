﻿// <auto-generated />
using System;
using LABSOLDAY14MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LABSOLDAY14MVC.Migrations
{
    [DbContext(typeof(C_TContext))]
    [Migration("20240918194337_create database")]
    partial class createdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.Property<int>("minDegree")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("id");

                    b.HasIndex("dept_id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Crs_Result", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("coursesid")
                        .HasColumnType("int");

                    b.Property<int?>("degree")
                        .HasColumnType("int");

                    b.Property<int>("grade")
                        .HasColumnType("int");

                    b.Property<int>("traineesid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("coursesid");

                    b.HasIndex("traineesid");

                    b.ToTable("Crs_Result");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Instructor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("imag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("crs_id");

                    b.HasIndex("dept_id");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Trainee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("imag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("dept_id");

                    b.ToTable("trainees");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Course", b =>
                {
                    b.HasOne("LABSOLDAY14MVC.Models.Department", "department")
                        .WithMany("courses")
                        .HasForeignKey("dept_id");

                    b.Navigation("department");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Crs_Result", b =>
                {
                    b.HasOne("LABSOLDAY14MVC.Models.Course", "Course")
                        .WithMany("crs_Results")
                        .HasForeignKey("coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LABSOLDAY14MVC.Models.Trainee", "Trainee")
                        .WithMany("crs_Results")
                        .HasForeignKey("traineesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Instructor", b =>
                {
                    b.HasOne("LABSOLDAY14MVC.Models.Course", "course")
                        .WithMany("instructor")
                        .HasForeignKey("crs_id");

                    b.HasOne("LABSOLDAY14MVC.Models.Department", "department")
                        .WithMany("instructors")
                        .HasForeignKey("dept_id");

                    b.Navigation("course");

                    b.Navigation("department");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Trainee", b =>
                {
                    b.HasOne("LABSOLDAY14MVC.Models.Department", "department")
                        .WithMany("trainees")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Course", b =>
                {
                    b.Navigation("crs_Results");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Department", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("instructors");

                    b.Navigation("trainees");
                });

            modelBuilder.Entity("LABSOLDAY14MVC.Models.Trainee", b =>
                {
                    b.Navigation("crs_Results");
                });
#pragma warning restore 612, 618
        }
    }
}
