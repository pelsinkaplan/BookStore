using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private ICategoryService categoryService;
        private IPublisherService publisherService;
        private IAuthorService authorService;

        public MenuViewComponent(ICategoryService categoryService,IPublisherService publisherService,IAuthorService authorService)
        {
            this.categoryService = categoryService;
            this.publisherService = publisherService;
            this.authorService = authorService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            var authors = authorService.GetAuthors();
            var publishers = publisherService.GetPublishers();
            return View(categories);
        }
    }
}
