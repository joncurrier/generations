using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly CookbookContext _context;

        public RecipesController(CookbookContext context)
        {
            _context = context;    
        }

        // GET: recipes/brownie-cookies
        public async Task<IActionResult> Details(string slug)
        {
            var recipe = await _context.Recipe
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .SingleOrDefaultAsync(m => m.Slug == slug);
            if (recipe == null)
            {
                return NotFound();
            }

            return View("Details", recipe);
        }
    }
}
