using BookStore.Models;
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private BookStoreDbContext dbContext;

        public BookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            book.Point = (int)(book.Rating * 10);
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return dbContext.Books.AsNoTracking().ToList();
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
        {
            return dbContext.Books.AsNoTracking().Where(b => b.CategoryId == categoryId).ToList();
        }

        public Book GetBooksById(int id)
        {

            return dbContext.Books.FirstOrDefault(x => x.Id == id);
        }
    }
}
