using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Remove(T entity);
        Task Update(T entity);
    }
}
