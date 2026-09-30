namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);

    }
}
