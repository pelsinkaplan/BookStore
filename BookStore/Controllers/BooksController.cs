using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private IBookService bookService;
        private ICategoryService categoryService;
        private IPublisherService publisherService;
        private IAuthorService authorService;

        public BooksController(IBookService bookService, ICategoryService categoryService,IPublisherService publisherService,IAuthorService authorService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.publisherService = publisherService;
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = GetCategoriesForSelect();
            List<SelectListItem> selectListItemsAuthors = GetAuthorsForSelect();
            List<SelectListItem> selectListItemsPublishers = GetPublishersForSelect();

            ViewBag.Items = selectListItems;
            ViewBag.ItemsAuthors = selectListItemsAuthors;
            ViewBag.ItemsPublishers = selectListItemsPublishers;

            return View();
        }

        private List<SelectListItem> GetCategoriesForSelect()
        {
            var categories = categoryService.GetCategories();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            categories.ToList().ForEach(cat => selectListItems.Add(new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }));
            return selectListItems;
        }

        private List<SelectListItem> GetAuthorsForSelect()
        {
            var authors = authorService.GetAuthors();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            authors.ToList().ForEach(cat => selectListItems.Add(new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }));
            return selectListItems;
        }

        private List<SelectListItem> GetPublishersForSelect()
        {
            var publishers = publisherService.GetPublishers();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            publishers.ToList().ForEach(cat => selectListItems.Add(new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }));
            return selectListItems;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
                return RedirectToAction(nameof(Index));

            }
            List<SelectListItem> selectListItems = GetCategoriesForSelect();
            List<SelectListItem> selectListItemsAuthors = GetAuthorsForSelect();
            List<SelectListItem> selectListItemsPublishers = GetPublishersForSelect();

            ViewBag.Items = selectListItems;
            ViewBag.ItemsAuthors = selectListItemsAuthors;
            ViewBag.ItemsPublishers = selectListItemsPublishers;

            return View();
        }
    }
}

