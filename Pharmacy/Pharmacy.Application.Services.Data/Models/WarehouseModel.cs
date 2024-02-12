using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
