using Microsoft.EntityFrameworkCore;

namespace CookbookApi.Models
{
    public class CookbookContext : DbContext
    {
        public CookbookContext(DbContextOptions<CookbookContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<Direction> Direction { get; set; }
    }
}
