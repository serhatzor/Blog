using Blog.Interfaces.Comment;
using BlogWebApi.Controllers;
using BlogWebApi.Tests.Base;
using System.Threading.Tasks;
using Xunit;

namespace BlogWebApi.Tests.Controllers
{
    public class CommentControllerTests : BaseControllerTests<Comment, CommentController, ICommentService>
    {

        [Fact]
        public override void ProviderIsNull()
        {
            base.ProviderIsNull();
        }

        [Fact]
        public override void ProviderIsNotNull()
        {
            base.ProviderIsNotNull();
        }

        [Fact]
        public override async Task GetAllReturnsSameAsWhatServiceReturns()
        {
            await base.GetAllReturnsSameAsWhatServiceReturns();
        }

        [Fact]
        public override async Task GetReturnsSameAsWhatServiceReturns()
        {
            await base.GetReturnsSameAsWhatServiceReturns();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public override async Task AddReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            await base.AddReturnsSameAsWhatServiceReturns(expectedResult);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public override async Task DeleteReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            await base.DeleteReturnsSameAsWhatServiceReturns(expectedResult);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public override async Task UpdateReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            await base.UpdateReturnsSameAsWhatServiceReturns(expectedResult);
        }
    }
}