using Blog.Interfaces.Comment;
using BlogWebApi.Integration.Tests.Base;
using BlogWebApi.Integration.Tests.Controllers.FakeServices;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlogWebApi.Integration.Tests.Controllers
{
    public partial class CommentControllerTests :
        BaseControllerTests<Comment, ICommentService, FakeCommentService>,
        IClassFixture<WebApplicationFactory<Startup>>
    {
        public CommentControllerTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory, "comment", FakeCommentService.Comments)
        {
        }

        public override Comment CreateNewEntity()
        {
            return new Comment()
            {
                Id = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
                Text = $"textcommentnewentity"
            };
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
