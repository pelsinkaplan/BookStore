using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Basket
    {
        private List<BookInBasket> books = new List<BookInBasket>();

        public void AddItem(Book book, int quantity)
        {
            var existingBook = books.FirstOrDefault(x => x.Book.Id == book.Id);
            if (existingBook == null)
            {
                BookInBasket bookInBasket = new BookInBasket();
                bookInBasket.Book = book;
                bookInBasket.Quantity = quantity;
                books.Add(bookInBasket);
            }
            else
            {
                existingBook.Quantity += quantity;
            }
        }
        public void DeleteItem(Book book) => books.RemoveAll(b => b.Book.Id == book.Id);


        public void DeleteAllItem() => books.Clear();


        public double getTotalPrice() => books.Sum(x => (double)(x.Book.Price - x.Book.Price * x.Book.DiscountRate / 100) * x.Quantity);


        public IEnumerable<BookInBasket> Books => books;
    }
}
