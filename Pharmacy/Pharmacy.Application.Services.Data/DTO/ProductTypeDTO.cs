namespace Pharmacy.Infrastructure.Data.DTO
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Properties { get; set; }
    }

    public class ProductTypeDetailsDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Properties { get; set; }

        public ICollection<ProductDTO>? Products { get; private set; }
    }
}
