
using Blog.Interfaces.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Implementations.Sql.Comment
{
    public class CommentService : ICommentService
    {
        public Task<bool> AddAsync(Interfaces.Comment.Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Interfaces.Comment.Comment>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Interfaces.Comment.Comment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Interfaces.Comment.Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
