﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platform.Database;

#nullable disable

namespace Platform.Database.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    partial class PlatformDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Platform.Core.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Platform.Core.Entities.Selection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("Platform.Core.Entities.SProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("72e6a758-2e61-4004-a99d-1db34db142b5"),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vel est id felis fringilla congue.",
                            Title = "Program 1"
                        },
                        new
                        {
                            Id = new Guid("916ff7d7-8d60-448c-98cf-69e0de66a0c1"),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus feugiat arcu risus, sed dapibus massa tincidunt nec. Duis.",
                            Title = "Program 2"
                        },
                        new
                        {
                            Id = new Guid("a4052592-6f44-408e-9a84-874ad01cd9a1"),
                            Description = "Mauris eget sapien sagittis, tincidunt magna nec, sagittis turpis. Phasellus aliquam tempus lorem vitae faucibus. Proin porttitor sit amet risus.",
                            Title = "Program 3"
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SelectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SelectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Platform.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbd91475-958c-44f6-b954-4b4858fddc99"),
                            Password = "iamdummy",
                            Username = "dummy"
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.Comment", b =>
                {
                    b.HasOne("Platform.Core.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Platform.Core.Entities.Student", "Student")
                        .WithMany("Comments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Author");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Platform.Core.Entities.Selection", b =>
                {
                    b.HasOne("Platform.Core.Entities.SProgram", "Program")
                        .WithMany("Selections")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.HasOne("Platform.Core.Entities.Selection", "Selection")
                        .WithMany("Students")
                        .HasForeignKey("SelectionId");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("Platform.Core.Entities.Selection", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Platform.Core.Entities.SProgram", b =>
                {
                    b.Navigation("Selections");
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}