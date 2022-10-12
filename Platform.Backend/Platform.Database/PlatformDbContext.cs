using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Database
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)   
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SProgram>().HasData(
                new SProgram { Id = Guid.NewGuid(), Title = "Program 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vel est id felis fringilla congue." },
                new SProgram { Id = Guid.NewGuid(), Title = "Program 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus feugiat arcu risus, sed dapibus massa tincidunt nec. Duis." },
                new SProgram { Id = Guid.NewGuid(), Title = "Program 3", Description = "Mauris eget sapien sagittis, tincidunt magna nec, sagittis turpis. Phasellus aliquam tempus lorem vitae faucibus. Proin porttitor sit amet risus." }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Username = "dummy", Password = "iamdummy" }
                );
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<SProgram> Programs { get; set; } = null!;
        public DbSet<Selection> Selections { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
