using Blog.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Implementations.Sql.Category
{
    public class CategoryService : ICategoryService
    {
        public Task<bool> AddAsync(Interfaces.Category.Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Interfaces.Category.Category>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Interfaces.Category.Category> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Interfaces.Category.Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
