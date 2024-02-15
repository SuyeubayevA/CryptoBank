namespace Pharmacy.Domain.Core
{
    public class ProductAmount: IEntity
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public float Discount { get; set; }

        //Navigation Property
        public virtual Product? Product { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
    }
}
