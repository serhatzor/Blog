using Blog.Interfaces.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Implementations.Sql.Post
{
    public class PostService : IPostService
    {
        public Task<bool> AddAsync(Interfaces.Post.Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Interfaces.Post.Post>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Interfaces.Post.Post> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Interfaces.Post.Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
