namespace Pharmacy.Infrastructure.Data.DTO
{
    public class WarehouseDTO
    {
        //Primary Key
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Address { get; set; }

    }

    public class WarehouseDetailsDTO
    {
        //Primary Key
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Address { get; set; }

        //Navigation Property
        public ICollection<ProductAmountDTO>? ProductAmounts { get; private set; }
    }
}
