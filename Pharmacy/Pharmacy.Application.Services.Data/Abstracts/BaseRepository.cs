using Pharmacy.Domain.Interfaces;

namespace Pharmacy.Infrastructure.Data.Abstracts
{
    public abstract class BaseRepository<T> : IPharmRepository<T> where T : class
    {
        private readonly PharmacyDBContext _db;
        public BaseRepository(PharmacyDBContext context)
        {
            _db = context;
        }
        public void Create(T item)
        {
            _db.Add(item);
        }

        public void Delete(int id)
        {
            var model = _db.Find<T>(id);
            if (model != null) _db.Remove(model);
        }

        public abstract Task<IEnumerable<T>?> GetAllAsync();

        public abstract Task<T?> GetAsync(int id);

        public void Update(T item)
        {
            _db.Update(item);
        }
    }
}
