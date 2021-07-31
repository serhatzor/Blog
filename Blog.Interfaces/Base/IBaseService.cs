using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Interfaces.Base
{
    public interface IBaseService<T> where T :  BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> RemoveByIdAsync(Guid id);
        Task<bool> UpdateAsync(T entity);
    }
}