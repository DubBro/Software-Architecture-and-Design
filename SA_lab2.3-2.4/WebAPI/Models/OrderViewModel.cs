using System.Collections.Generic;

namespace WebAPI.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public string Details { get; set; }
        public IEnumerable<DishViewModel> Dishes { get; set; }
    }
}