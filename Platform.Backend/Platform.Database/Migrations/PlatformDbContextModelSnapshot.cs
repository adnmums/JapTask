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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Platform.Core.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Platform.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "8417836b-e218-4f36-96fe-6bc9932d0601",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "54e356f0-550b-4acf-a8b7-7dc419b0159f",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.Selection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProgramId")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("4c2b95e0-2022-4a8f-b537-eb3a32786b06"),
                            EndDate = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgramId = new Guid("b950ddf5-e9ad-47ff-9d2a-57259014fae6"),
                            StartDate = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 1,
                            Title = "Selection Curabitur"
                        },
                        new
                        {
                            Id = new Guid("a1066e97-c7c8-4aee-905b-61bb31d82bfb"),
                            EndDate = new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgramId = new Guid("907f54ba-2142-4719-aef9-6230c23bd7de"),
                            StartDate = new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            Title = "Selection Aenean"
                        },
                        new
                        {
                            Id = new Guid("30f96ef9-7b45-42f7-9fab-05a70e7fc394"),
                            EndDate = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgramId = new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                            StartDate = new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            Title = "Selection Donec"
                        });
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
                            Id = new Guid("b950ddf5-e9ad-47ff-9d2a-57259014fae6"),
                            Description = "Curabitur bibendum, ipsum non pulvinar finibus, elit magna hendrerit velit.",
                            Title = "Curabitur"
                        },
                        new
                        {
                            Id = new Guid("907f54ba-2142-4719-aef9-6230c23bd7de"),
                            Description = "Aenean faucibus sit amet metus pellentesque ultrices. Aenean vestibulum suscipit.",
                            Title = "Aenean"
                        },
                        new
                        {
                            Id = new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                            Description = "Donec sit amet sollicitudin nunc. Phasellus varius nisi sapien, in.",
                            Title = "Donec"
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5d16c248-712c-4d03-9b56-50d7b23d7e3e",
                            EmailConfirmed = false,
                            FirstName = "Johnny",
                            LastName = "Cash",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEIScS12FfiRbsIilSztDuFfTs1gGmyE27O0FwJHoZ7hSDWmt0KJncClf89VaU/blGw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.HasBaseType("Platform.Core.Entities.User");

                    b.Property<Guid?>("SelectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasIndex("SelectionId");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1974, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e4527724-3e30-444d-a014-805f5002909c",
                            EmailConfirmed = false,
                            FirstName = "Rasheed",
                            LastName = "Wallace",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEORdPdguQhQWv5GSM+g3GPdGY+TTgTewqCSynPef/qbf8DZ1/7uFW4MGj305ZxCDsw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "sheed",
                            SelectionId = new Guid("4c2b95e0-2022-4a8f-b537-eb3a32786b06"),
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1976, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "c01e3b43-146c-4509-a12f-34ce489683ed",
                            EmailConfirmed = false,
                            FirstName = "Allen",
                            LastName = "Iverson",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEKyzWwV53RkysPBF5uB79y6RdLUDz1K/YFQrPZ3cl5xrZim3w2MtMQ9h96/tA06K2Q==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "answer",
                            SelectionId = new Guid("a1066e97-c7c8-4aee-905b-61bb31d82bfb"),
                            Status = 2
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e70fd0bf-2fef-43e8-8f5f-a61e0a8b50b4",
                            EmailConfirmed = false,
                            FirstName = "Vince",
                            LastName = "Carter",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEOKsjC1byRokPI5f4Mwi3nZ65OA4yRXca6sCKXf9/dLL5PtfJ2aZFUs+0nKZ0WmyQw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "vinsanity",
                            SelectionId = new Guid("a1066e97-c7c8-4aee-905b-61bb31d82bfb"),
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1978, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "15ea3d6e-9a87-4449-b245-e07c018fc5a4",
                            EmailConfirmed = false,
                            FirstName = "Gary",
                            LastName = "Payton",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEAeI3v1Z/d8vkQy6wjCbqFh/vZkRvbm8gADWoQciWXzytxFF5q8+nGpQHyFOP0zJrg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "glove",
                            SelectionId = new Guid("30f96ef9-7b45-42f7-9fab-05a70e7fc394"),
                            Status = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Platform.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Platform.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Platform.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Platform.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Platform.Core.Entities.UserRole", b =>
                {
                    b.HasOne("Platform.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Platform.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.HasOne("Platform.Core.Entities.Selection", "Selection")
                        .WithMany("Students")
                        .HasForeignKey("SelectionId");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("Platform.Core.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Platform.Core.Entities.Selection", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Platform.Core.Entities.SProgram", b =>
                {
                    b.Navigation("Selections");
                });

            modelBuilder.Entity("Platform.Core.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Platform.Core.Entities.Student", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
