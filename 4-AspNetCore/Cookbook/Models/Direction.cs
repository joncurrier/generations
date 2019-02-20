namespace Cookbook.Models
{
    public class Direction
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public string Text { get; set; }
        public int Ordinal { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
