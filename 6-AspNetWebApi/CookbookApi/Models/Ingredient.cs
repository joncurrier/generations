using Newtonsoft.Json;

namespace CookbookApi.Models
{
    public partial class Ingredient
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int RecipeID { get; set; }
        [JsonIgnore]
        public double Quantity { get; set; }
        [JsonIgnore]
        public string Unit { get; set; }
        [JsonIgnore]
        public string Food { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}
