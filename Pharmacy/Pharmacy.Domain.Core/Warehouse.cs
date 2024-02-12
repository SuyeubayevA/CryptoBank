namespace Pharmacy.Domain.Core
{
    public class Warehouse: IEntity
    {
        public Warehouse()
        {
            this.ProductAmounts = new HashSet<ProductAmount>();
        }

        //Primary Key
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        //Navigation Property
        public virtual ICollection<ProductAmount> ProductAmounts { get; private set; }
    }
}
