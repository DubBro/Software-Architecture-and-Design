using System.Collections.Generic;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public string Details { get; set; }
        public IEnumerable<DishDTO> Dishes { get; set; }
    }
}
