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
    public class CommentsController : Controller
    {
        private readonly BookStoreDbContext _context;

        public CommentsController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.Comments.Include(c => c.Book);
            return View(await bookStoreDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommentString,BookId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", comment.BookId);
            return View(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
