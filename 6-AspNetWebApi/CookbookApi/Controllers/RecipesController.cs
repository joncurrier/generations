using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookbookApi.Models;

namespace CookbookApi.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly CookbookContext _context;

        public RecipesController(CookbookContext context)
        {
            _context = context;
        }

        // GET: api/recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipe.ToListAsync();
        }

        // GET: api/recipes/brownie-cookies
        [HttpGet("{slug}")]
        public async Task<ActionResult<Recipe>> GetRecipe([FromRoute] string slug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = await _context.Recipe.Include(r => r.Ingredients)
                                              .Include(r => r.Directions)
                                              .SingleOrDefaultAsync(r => r.Slug == slug);

            recipe.Directions = recipe.Directions.OrderBy(d => d.Ordinal).ToList();

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }
    }
}
