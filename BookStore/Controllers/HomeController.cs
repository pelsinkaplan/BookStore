using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookService bookService;
        private IPublisherService publisherService;
        private IAuthorService authorService;
        public HomeController(ILogger<HomeController> logger, IBookService bookService, IPublisherService publisherService, IAuthorService authorService)
        {
            _logger = logger;
            this.publisherService = publisherService;
            this.bookService = bookService;
            this.authorService = authorService;
        }

        public IActionResult Index(int page = 1, int catid = 0)
        {
            var pageSize = 4;
            var books = catid == 0 ? bookService.GetBooks() : bookService.GetBooksByCategoryId(catid);

            var pagingBooks = books.OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize) // atlanacak eleman sayısı
                .Take(pageSize); // atladıktan sonra alınacak eleman sayısı

            ViewBag.CatId = catid;

            var totalBook = books.Count;
            var totalPages = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPages;
            ViewBag.PublishersList = publisherService.GetPublishers();
            ViewBag.AuthorsList = authorService.GetAuthors();
            return View(pagingBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
