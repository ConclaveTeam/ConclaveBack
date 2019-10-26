using Common;
using Common.Encryption;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Themes> Themes { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var deanSalt = Salt.Create();
            var goodUser = new User
            {
                Id = 1,
                Login = "GoodUser",
                FirstName = "Petr",
                LastName = "Ivanov",

                Salt = deanSalt,
                Password = Hash.Create("123", deanSalt)
            };

            var badUser = new User
            {
                Id = 1,
                Login = "BadUser",
                FirstName = "Petr",
                LastName = "Ivanov",

                Salt = deanSalt,
                Password = Hash.Create("123", deanSalt),
                IsFrozenUser = true
            };

            var users = new List<User>
            {
                goodUser,
                badUser
            };

            builder.Entity<User>().HasData(users);
        }
    }
}
