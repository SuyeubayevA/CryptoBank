namespace Pharmacy.Domain.Interfaces
{
    public interface IPharmRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetAsync(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
