namespace Pharmacy.Infrastructure.Data.DTO
{
    public class ProductAmountDTO
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public float Discount { get; set; }

        //Navigation Property
        public string? ProductName { get; set; }
        public string? WarehouseName { get; set; }
    }

    public class ProductAmountDetailsDTO
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }
        public float Discount { get; set; }

        //Navigation Property
        public ProductDTO? Product { get; set; }
        public WarehouseDTO? Warehouse { get; set; }
    }
}
