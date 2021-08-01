using Blog.Interfaces.Post;
using BlogWebApi.Integration.Tests.Base;
using BlogWebApi.Integration.Tests.Controllers.FakeServices;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlogWebApi.Integration.Tests.Controllers
{
    public partial class PostControllerTests :
        BaseControllerTests<Post, IPostService, FakePostService>,
        IClassFixture<WebApplicationFactory<Startup>>
    {
        public PostControllerTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory, "post", FakePostService.Posts)
        {
        }

        public override Post CreateNewEntity()
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid()
            };
        }

        public override string GetIsStringForGetAll()
        {
            return @"
            [
                {
                    CategoryId = guid-0
                    Id = guid-1
                }
            ]";
        }

        public override string GetIsStringForGetById()
        {
            return @"
            {
                CategoryId = guid-0
                Id = guid-1
            }";
        }

        public override string GetIsStringForPost()
        {
            return @"
            {
                CategoryId = guid-0
                Id = guid-1
            }";
        }

        public override string GetIsStringForUpdate()
        {
            return @"
            {
                CategoryId = guid-0
                Id = guid-1
            }";
        }

        [Fact]
        public override async Task GetAllTest()
        {
            await base.GetAllTest();
        }

        [Fact]
        public override async Task GetByIdTest()
        {
            await base.GetByIdTest();
        }

        [Fact]
        public override async Task PostTest()
        {
            await base.PostTest();
        }

        [Fact]
        public override async Task UpdateTest()
        {
            await base.UpdateTest();
        }

        [Fact]
        public override async Task RemoveTest()
        {
            await base.RemoveTest();
        }

    }
}
