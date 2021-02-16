using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers
{
    public class Books1Controller : Controller
    {
        private IBookService bookService;
        private ICategoryService categoryService;
        private IPublisherService publisherService;
        private IAuthorService authorService;
        private readonly BookStoreDbContext _context;

        public Books1Controller(BookStoreDbContext context, IBookService bookService, ICategoryService categoryService, IPublisherService publisherService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.publisherService = publisherService;
            this.authorService = authorService;
            _context = context;
        }

        // GET: Books1
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: Books1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books1/Create
        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = GetCategoriesForSelect();
            List<SelectListItem> selectListItemsAuthors = GetAuthorsForSelect();
            List<SelectListItem> selectListItemsPublishers = GetPublishersForSelect();

            ViewBag.Items = selectListItems;
            ViewBag.ItemsAuthors = selectListItemsAuthors;
            ViewBag.ItemsPublishers = selectListItemsPublishers;
            
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id");
            return View();
        }

        // POST: Books1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Price,Content,PageNumber,Point,Rating,ReleaseDate,DiscountRate,SoldNumber,CategoryId,PublisherId,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Books1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            List<SelectListItem> selectListItems = GetCategoriesForSelect();
            List<SelectListItem> selectListItemsAuthors = GetAuthorsForSelect();
            List<SelectListItem> selectListItemsPublishers = GetPublishersForSelect();

            ViewBag.Items = selectListItems;
            ViewBag.ItemsAuthors = selectListItemsAuthors;
            ViewBag.ItemsPublishers = selectListItemsPublishers;

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // POST: Books1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Price,Content,PageNumber,Point,Rating,ReleaseDate,DiscountRate,SoldNumber,CategoryId,PublisherId,AuthorId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> selectListItems = GetCategoriesForSelect();
            List<SelectListItem> selectListItemsAuthors = GetAuthorsForSelect();
            List<SelectListItem> selectListItemsPublishers = GetPublishersForSelect();

            ViewBag.Items = selectListItems;
            ViewBag.ItemsAuthors = selectListItemsAuthors;
            ViewBag.ItemsPublishers = selectListItemsPublishers;

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Books1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
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
    }
}
