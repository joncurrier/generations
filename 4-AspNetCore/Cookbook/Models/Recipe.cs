using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookbook.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Int64? PrepTime { get; set; }
        public Int64? WaitTime { get; set; }
        public Int64? CookTime { get; set; }
        public string Yields { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }

        [NotMapped]
        public TimeSpan? GetPrepTime
        {
            get
            {
                if (PrepTime.HasValue)
                {
                    return TimeSpan.FromSeconds(PrepTime.Value);
                }
                else
                {
                    return null;
                }
                
            }
        }

        [NotMapped]
        public TimeSpan? GetWaitTime
        {
            get
            {
                if (WaitTime.HasValue)
                {
                    return TimeSpan.FromSeconds(WaitTime.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        [NotMapped]
        public TimeSpan? GetCookTime
        {
            get
            {
                if (CookTime.HasValue)
                {
                    return TimeSpan.FromSeconds(CookTime.Value);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
