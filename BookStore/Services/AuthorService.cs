using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private BookStoreDbContext dbContext;

        public AuthorService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        IList<Author> IAuthorService.GetAuthors()
        {
            return dbContext.Author.AsNoTracking().ToList();
        }

        IList<Book> IAuthorService.GetBooks(int id)
        {
            List<Book> books = new List<Book>();
            foreach (var book in dbContext.Books)
            {
                if (book.AuthorId == id)
                    books.Add(book);
            }
            return books;
        }
    }
}
