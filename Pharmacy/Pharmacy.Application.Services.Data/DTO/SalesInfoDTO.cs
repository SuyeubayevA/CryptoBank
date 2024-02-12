namespace Pharmacy.Infrastructure.Data.DTO
{
    public class SalesInfoDTO
    {
        public int Sales { get; set; }
        public int ProductReminder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int ProductId { get; set; }
    }

    public class SalesInfoDetailsDTO
    {
        public int Id { get; set; }
        public int Sales { get; set; }
        public int ProductReminder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

        //Foreign Key
        public int ProductId { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
