namespace Storage.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
