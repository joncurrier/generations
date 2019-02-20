namespace Cookbook.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Food { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
