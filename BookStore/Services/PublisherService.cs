using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class PublisherService : IPublisherService
    {
        private BookStoreDbContext dbContext;

        public PublisherService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Book> GetBooks(int id)
        {
            List<Book> books = new List<Book>();
            foreach (var book in dbContext.Books)
            {
                if (book.PublisherId == id)
                    books.Add(book);
            }
            return books;
        }

        public IList<Publisher> GetPublishers()
        {
            return dbContext.Publisher.AsNoTracking().ToList();
        }


    }
}
