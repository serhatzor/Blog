using Blog.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Integration.Tests.Controllers.FakeServices
{
    public class FakeCategoryService : ICategoryService
    {
        public static readonly List<Category> Categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    NameResourceKey = "test1fake",
                    DescriptionResourceKey = "test1fake"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    NameResourceKey = "test2fake",
                    DescriptionResourceKey = "test2fake"
                }
            };

        public Task<bool> AddAsync(Category entity)
        {
            Categories.Add(entity);
            return Task.FromResult(true);
        }

        public Task<List<Category>> GetAsync()
        {
            return Task.FromResult(Categories);
        }

        public Task<Category> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Categories.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            Categories.Remove(Categories.FirstOrDefault(x => x.Id == id));
            return Task.FromResult(true);
        }

        public Task<bool> UpdateAsync(Category entity)
        {
            Category existingCategory = Categories.FirstOrDefault(x => x.Id == entity.Id);
            existingCategory.NameResourceKey = entity.NameResourceKey;
            existingCategory.DescriptionResourceKey = entity.DescriptionResourceKey;
            return Task.FromResult(true);
        }
    }
}
