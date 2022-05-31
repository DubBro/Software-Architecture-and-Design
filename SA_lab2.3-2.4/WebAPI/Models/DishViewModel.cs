namespace WebAPI.Models
{
    public class DishViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int[] Days { get; set; }
    }
}