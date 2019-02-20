using System;
using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;

namespace CookbookApi.Models
{
    public partial class Recipe
    {
        [NotMapped]
        public string GetPrepTime
        {
            get
            {
                if (PrepTime.HasValue)
                {
                    return TimeSpan.FromSeconds(PrepTime.Value).Humanize();
                }
                else
                {
                    return null;
                }

            }
        }

        [NotMapped]
        public string GetWaitTime
        {
            get
            {
                if (WaitTime.HasValue)
                {
                    return TimeSpan.FromSeconds(WaitTime.Value).Humanize();
                }
                else
                {
                    return null;
                }
            }
        }

        [NotMapped]
        public string GetCookTime
        {
            get
            {
                if (CookTime.HasValue)
                {
                    return TimeSpan.FromSeconds(CookTime.Value).Humanize();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
