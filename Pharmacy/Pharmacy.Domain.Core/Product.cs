namespace Pharmacy.Domain.Core
{
    public class Product: IEntity
    {
        //Primary Key
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }

        //Foreign Key
        public int ProductTypeId { get; set; }
        public int SalesInfoId { get; set; }

        //Navigation Property
        public virtual ProductType? ProductType { get; set; }
        public virtual SalesInfo? SalesInfo { get; set; }
        public virtual ICollection<ProductAmount> ProductAmounts { get; set; }
    }
}
