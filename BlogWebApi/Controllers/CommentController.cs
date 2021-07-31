using Blog.Interfaces.Comment;
using BlogWebApi.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseApiController<Comment>
    {
        public CommentController(ICommentService commentProvider) : base(commentProvider)
        {
        }

        [HttpGet]
        public override async Task<List<Comment>> Get()
        {
            return await base.Get();
        }

        [HttpGet("{id}")]
        public override async Task<Comment> Get(Guid id)
        {
            return await base.Get(id);
        }

        [HttpPost]
        public override async Task<bool> Post([FromBody] Comment entity)
        {
            return await base.Post(entity);
        }

        [HttpPut()]
        public override async Task<bool> Put([FromBody] Comment entity)
        {
            return await base.Put(entity);
        }

        [HttpDelete("{id}")]
        public override async Task<bool> Delete(Guid id)
        {
            return await base.Delete(id);
        }
    }
}