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
        public DbSet<Theme> Themes { get; set; }

        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var goodUserSalt = Salt.Create();
            var badUserSalt = Salt.Create();

            var goodUser = new User
            {
                Id = 1,
                Login = "GoodUser",
                FirstName = "Alex",
                LastName = "Petrov",
                IsFrozenUser = false,

                Salt = goodUserSalt,
                Password = Hash.Create("123", goodUserSalt)
            };

            var badUser = new User
            {
                Id = 2,
                Login = "BadUser",
                FirstName = "Petr",
                LastName = "Maxsimov",
                IsFrozenUser = true,

                Salt = badUserSalt,
                Password = Hash.Create("1488", goodUserSalt)
            };

            var users = new List<User>()
            {
                goodUser,
                badUser
            };


            var author1 = new Author
            {
                Id = 1,
                UserId = goodUser.Id
            };

            var author2 = new Author
            {
                Id = 2,
                UserId = badUser.Id
            };

            var authors = new List<Author>()
            {
                author1,
                author2
            };

            var theme1 = new Theme
            {
                Id = 1,
                Name = "Conclave theme"
            };

            var theme2 = new Theme
            {
                Id = 2,
                Name = "Memes theme"
            };

            var themes = new List<Theme>()
            {
                theme1,
                theme2
            };

            var post1 = new Post
            {
                Id = 1,
                Title = "Post1ForConclaveTheme",
                ThemeId = theme1.Id,
                DatePosted = DateTime.Now,
                Text = "Simple text for post1",
                AuthorId = author1.Id
            };

            var post2 = new Post
            {
                Id = 2,
                Title = "Post2ForConclaveTheme",
                ThemeId = theme1.Id,
                DatePosted = DateTime.Now,
                Text = "Simple text for post2",
                AuthorId = author1.Id
            };

            var post3 = new Post
            {
                Id = 3,
                Title = "Post3ForMemesTheme",
                DatePosted = DateTime.Now,
                Text = "Simple text for post3",
                AuthorId = author2.Id,
                ThemeId = theme2.Id
            };

            var posts = new List<Post>()
            {
                post1,
                post2,
                post3
            };

            var commentForPost1 = new Comment
            {
                Id = 1,
                Text = "AuthorCommentTextOfPost1",
                AuthorId = author1.Id,
                PostId = post1.Id
            };

            var subCommentForPost1 = new Comment
            {
                Id = 2,
                Text = "SubCommentForPost1",
                AuthorId = author1.Id,
                PostId = post1.Id,

                ParentCommentId = commentForPost1.Id
            };

            var commentForPost2 = new Comment
            {
                Id = 3,
                Text = "AuthorCommentTextOfPost2",
                AuthorId = author2.Id,
                PostId = post2.Id
            };

            var comments = new List<Comment>()
            {
                commentForPost1,
                subCommentForPost1,
                commentForPost2
            };

            modelBuilder.Entity<Comment>().HasOne(c => c.ParentComment).WithMany(c => c.Comments)
            .HasForeignKey(c => c.ParentCommentId)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Comment>().HasOne(p => p.Post).WithMany(c => c.Comments)
            .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Theme>().HasData(themes);
            modelBuilder.Entity<Post>().HasData(posts);
            modelBuilder.Entity<Comment>().HasData(comments);
        }
    }
}
