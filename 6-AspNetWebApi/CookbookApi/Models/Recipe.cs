using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CookbookApi.Models
{
    public partial class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Int64? PrepTime { get; set; }
        [JsonIgnore]
        public Int64? WaitTime { get; set; }
        [JsonIgnore]
        public Int64? CookTime { get; set; }
        public string Yields { get; set; }
        [JsonIgnore]
        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
