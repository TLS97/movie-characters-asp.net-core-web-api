namespace MovieCharactersAPI.Services
{
    public interface ICrudService<T, ID>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(ID id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(ID id);
    }
}
