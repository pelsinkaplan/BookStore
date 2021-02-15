using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<Book> GetBooksByCategoryId(int categoryId);
        void AddBook(Book book);
        Book GetBooksById(int id);
    }
}