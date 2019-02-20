using Newtonsoft.Json;

namespace CookbookApi.Models
{
    public partial class Direction
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int RecipeID { get; set; }
        public int Ordinal { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}
