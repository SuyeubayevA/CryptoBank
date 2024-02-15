using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class ProductAmountModel
    {
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
