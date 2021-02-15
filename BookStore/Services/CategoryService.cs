using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private BookStoreDbContext dbContext;

        public CategoryService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Category> GetCategories()
        {
            return dbContext.Categories.AsNoTracking().ToList();
        }
    }
}
