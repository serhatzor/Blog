﻿using Blog.Interfaces.Category;
using BlogWebApi.Integration.Tests.Base;
using BlogWebApi.Integration.Tests.Controllers.FakeServices;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlogWebApi.Integration.Tests.Controllers
{
    public partial class CategoryControllerTests :
        BaseControllerTests<Category, ICategoryService, FakeCategoryService>,
        IClassFixture<WebApplicationFactory<Startup>>
    {
        public CategoryControllerTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory, "category", FakeCategoryService.Categories)
        {
        }

        public override Category CreateNewEntity()
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                NameResourceKey = $"testnameresourcekeynewentity",
                DescriptionResourceKey = $"testdescriptionresourcekeynewentity"
            };
        }

        public override string GetIsStringForGetAll()
        {
            return @"
            [
                {
                    NameResourceKey = `testnameresourcekeynewentity`
                    DescriptionResourceKey = `testdescriptionresourcekeynewentity`
                    Id = guid-0
                },
                {
                    NameResourceKey = `testnameresourcekeynewentity`
                    DescriptionResourceKey = `testdescriptionresourcekeynewentity`
                    Id = guid-1
                }
            ]";
        }

        public override string GetIsStringForGetById()
        {
            return @"
            {
                NameResourceKey = `test2fake`
                DescriptionResourceKey = `test2fake`
                Id = guid-0
            }";
        }

        public override string GetIsStringForPost()
        {
            return @"
            {
                NameResourceKey = `testnameresourcekeynewentity`
                DescriptionResourceKey = `testdescriptionresourcekeynewentity`
                Id = guid-0
            }";
        }

        public override string GetIsStringForUpdate()
        {
            return @"
            {
                NameResourceKey = `testnameresourcekeynewentity`
                DescriptionResourceKey = `testdescriptionresourcekeynewentity`
                Id = guid-0
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
