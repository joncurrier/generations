using System.Collections.Generic;

namespace Cookbook.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public string Slug { get; set; }
        public int Ordinal { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
