using Blog.Interfaces.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Integration.Tests.Controllers.FakeServices
{
    public class FakeCommentService : ICommentService
    {
        public static readonly List<Comment> Comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = Guid.NewGuid(),
                    PostId = Guid.NewGuid(),
                    Text = $"testtextfake"
                }
            };

        public Task<bool> AddAsync(Comment entity)
        {
            Comments.Add(entity);
            return Task.FromResult(true);
        }

        public Task<List<Comment>> GetAsync()
        {
            return Task.FromResult(Comments);
        }

        public Task<Comment> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Comments.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> RemoveByIdAsync(Guid id)
        {
            Comments.Remove(Comments.FirstOrDefault(x => x.Id == id));
            return Task.FromResult(true);
        }

        public Task<bool> UpdateAsync(Comment entity)
        {
            Comment existingComment = Comments.FirstOrDefault(x => x.Id == entity.Id);
            existingComment.PostId = entity.PostId;
            existingComment.Text = entity.Text;
            return Task.FromResult(true);
        }
    }
}
