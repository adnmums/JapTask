﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Database.Configurations;

namespace Platform.Database
{
    public class PlatformDbContext : IdentityDbContext
        <User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramConfiguration());
            modelBuilder.ApplyConfiguration(new SelectionConfiguration());
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<SProgram> Programs { get; set; } = null!;
        public DbSet<Selection> Selections { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
