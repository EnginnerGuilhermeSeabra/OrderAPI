using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);

        Task<List<T>> GetAll();

        ValueTask<T> GetByIdAsync(string id);

        T Update(T entity);

        void Remove(T entity);

        Task SaveChanges();
    }
}
