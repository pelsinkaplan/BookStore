using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasOne(x => x.Category)
                        .WithMany(y => y.Books)
                        .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Book>()
                        .HasOne(x => x.Author)
                        .WithMany(y => y.Books)
                        .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Book>()
                        .HasOne(x => x.Publisher)
                        .WithMany(y => y.Books)
                        .HasForeignKey(x => x.PublisherId);

            modelBuilder.Entity<Comment>()
                       .HasOne(x => x.Book)
                       .WithMany(y => y.Comments)
                       .HasForeignKey(x => x.BookId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BookStore.Models.Order> Order { get; set; }
    }
}
