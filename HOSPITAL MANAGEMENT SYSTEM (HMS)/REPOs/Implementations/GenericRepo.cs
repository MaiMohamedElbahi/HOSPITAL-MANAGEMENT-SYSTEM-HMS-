using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Data;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }
        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            _db.Remove(_db.Find(id));
        }

        public List<T> GetAll()
        {
           return _db.ToList();
        }

        public T GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
