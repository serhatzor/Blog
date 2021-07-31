using Blog.Interfaces.Post;
using BlogWebApi.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseApiController<Post>
    {
        public PostController(IPostService postProvider) : base(postProvider)
        {
        }

        [HttpGet]
        public override async Task<List<Post>> Get()
        {
            return await base.Get();
        }

        [HttpGet("{id}")]
        public override async Task<Post> Get(Guid id)
        {
            return await base.Get(id);
        }

        [HttpPost]
        public override async Task<bool> Post([FromBody] Post entity)
        {
            return await base.Post(entity);
        }

        [HttpPut()]
        public override async Task<bool> Put([FromBody] Post entity)
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