using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class SalesInfoModel
    {
        public int Id { get; set; }

        [Required]
        public int Sales { get; set; }
        [Required]
        public int ProductReminder { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
