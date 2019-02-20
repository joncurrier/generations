using Cookbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cookbook.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly CookbookContext db;

        public SidebarViewComponent(CookbookContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            if (ViewData.Model is Recipe recipe)
            {
                ViewData["recipeID"] = recipe.ID;
            }
            return View(categories);
        }

        private Task<List<Category>> GetCategoriesAsync()
        {
            return db.Category.Include(c => c.Recipes).ToListAsync();
        }
    }
}
