using System.Linq.Expressions;

namespace DataAccess
{
    public interface IRepository : IDisposable
    {
        Task<List<T>> GetAllDataListAsync<T, TProperty>(Expression<Func<T, bool>> filter, params Expression<Func<T, TProperty>>[] includes)
            where T : class;
        Task<T> GetDataByIdAsync<T, TProperty>(Expression<Func<T, bool>> filter, params Expression<Func<T, TProperty>>[] includes)
            where T : class;
        Task<T> CreateAsync<T>(T item)
            where T : class;
        Task<T> UpdateAsync<T>(T item)
            where T : class;
        Task DeleteAsync<T>(int id)
            where T : class;
    }
}
