using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BasketController : Controller
    {
        private IBookService bookService;

        public BasketController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string returnUrl)
        {
            var basket = GetBasket();
            ViewBag.ReturnUrl = returnUrl;
            return View(basket);
        }
        [HttpPost]
        public IActionResult AddToBasket(int id, string returnUrl)
        {
            var selectedBook = bookService.GetBooksById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }
            Basket basket = GetBasket() ?? new Basket();
            basket.AddItem(selectedBook, 1);
            SaveBasket(basket);
            return RedirectToAction(nameof(Index), nameof(Basket), new { returnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult RemoveItemsInBasket(int id)
        {
            var selectedBook = bookService.GetBooksById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }
            Basket basket = GetBasket() ?? new Basket();
            basket.DeleteItem(selectedBook);
            SaveBasket(basket);
            return RedirectToAction(nameof(Index), nameof(Basket));
        }

        [HttpPost]
        public IActionResult RemoveAllItemsInBasket()
        {
            bookService.GetBooks().Clear();
            return RedirectToAction(nameof(Index), nameof(Basket));
        }

        Basket GetBasket()
        {
            var data = HttpContext.Session.GetString("Sepetim");
            if (data == null) return null;
            else return JsonConvert.DeserializeObject<Basket>(data);
        }

        void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetString("Sepetim", JsonConvert.SerializeObject(basket));
        }
    }
}
