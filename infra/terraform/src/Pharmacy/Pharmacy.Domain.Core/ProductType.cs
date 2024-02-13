namespace Pharmacy.Domain.Core
{
    public class ProductType: IEntity
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        //Primary Key
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;

        //Navigation Property
        public virtual ICollection<Product> Products { get; private set; }
    }
}
