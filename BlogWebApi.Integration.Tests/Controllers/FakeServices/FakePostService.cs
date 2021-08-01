using Blog.Interfaces.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Integration.Tests.Controllers.FakeServices
{
    public class FakePostService : IPostService
    {
        public static readonly List<Post> Posts = new List<Post>()
            {
                new Post()
                {
                    Id = Guid.NewGuid(),
                    CategoryId = Guid.NewGuid()
                }
            };

        public Task<bool> AddAsync(Post entity)
        {
            Posts.Add(entity);
            return Task.FromResult(true);
        }

        public Task<List<Post>> GetAsync()
        {
            return Task.FromResult(Posts);
        }

        public Task<Post> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Posts.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            Posts.Remove(Posts.FirstOrDefault(x => x.Id == id));
            return Task.FromResult(true);
        }

        public Task<bool> UpdateAsync(Post entity)
        {
            Post existingPost = Posts.FirstOrDefault(x => x.Id == entity.Id);
            existingPost.CategoryId = entity.CategoryId;
            return Task.FromResult(true);
        }
    }
}
