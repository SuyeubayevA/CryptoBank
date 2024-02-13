namespace Pharmacy.Domain.Core
{
    public class SalesInfo: IEntity
    {
        //Primary Key
        public int Id { get; set; }
        public int Sales { get; set; }
        public int ProductReminder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

        //Foreign Key
        public int ProductId { get; set; }
        //Navigation Property
        public virtual Product? Product { get; set; }
    }
}
