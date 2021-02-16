using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BookPageController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookPageController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: BookPage
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher).Include(b => b.Comments);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: BookPage/Details/5
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
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.BookId = id;

            return View(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
