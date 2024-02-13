using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int ProductTypeId { get; set; }
        public int SalesInfoId { get; set; }

        public float Price { get; set; }
    }
}
