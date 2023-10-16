using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "MONEY")]
        public decimal Price { get; set; }
    }
}
