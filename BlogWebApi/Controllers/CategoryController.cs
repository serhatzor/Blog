using Blog.Interfaces.Category;
using BlogWebApi.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController<Category>
    {
        public CategoryController(ICategoryService categoryProvider) : base(categoryProvider)
        {
        }

        [HttpGet]
        public override async Task<List<Category>> Get()
        {
            return await base.Get();
        }

        [HttpGet("{id}")]
        public override async Task<Category> Get(Guid id)
        {
            return await base.Get(id);
        }

        [HttpPost]
        public override async Task<bool> Post([FromBody] Category entity)
        {
            return await base.Post(entity);
        }

        [HttpPut()]
        public override async Task<bool> Put([FromBody] Category entity)
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