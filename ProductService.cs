using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace MicroserviciosNetCore3
{
    public class Product
    {
        public int Id { get; set; }
        [Required] // DataNotation
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
