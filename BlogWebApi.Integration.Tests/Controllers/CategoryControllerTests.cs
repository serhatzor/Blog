using Blog.Interfaces.Category;
using BlogWebApi.Integration.Tests.Controllers.FakeServices;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ReassureTest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace BlogWebApi.Integration.Tests.Controllers
{
    public partial class CategoryControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;

        public CategoryControllerTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;

            this.webApplicationFactory.Server.BaseAddress = new Uri("http://localhost/");
            this.webApplicationFactory = this.webApplicationFactory.WithWebHostBuilder((builder) =>
            {
                builder.ConfigureServices((services) =>
                {
                    services.AddScoped<ICategoryService, FakeCategoryService>();
                });
            });
            httpClient = this.webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task GetAllTest()
        {
            HttpResponseMessage response = await this.httpClient.GetAsync("/api/category");

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            List<Category> actualCategories = JsonConvert.DeserializeObject<List<Category>>(responseJson);

            for (int i = 0; i < actualCategories.Count; i++)
            {
                actualCategories[i].Id.Should().Be(FakeCategoryService.Categories[i].Id);
                actualCategories[i].NameResourceKey.Should().Be(FakeCategoryService.Categories[i].NameResourceKey);
                actualCategories[i].DescriptionResourceKey.Should().Be(FakeCategoryService.Categories[i].DescriptionResourceKey);
            }

        }

        [Fact]
        public async Task GetByIdTest()
        {
            Category firstTestCategory = FakeCategoryService.Categories[0];

            HttpResponseMessage response = await this.httpClient.GetAsync($"/api/category/{firstTestCategory.Id}");

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            Category actualCategory = JsonConvert.DeserializeObject<Category>(responseJson);

            actualCategory.Id.Should().Be(firstTestCategory.Id);
            actualCategory.NameResourceKey.Should().Be(firstTestCategory.NameResourceKey);
            actualCategory.DescriptionResourceKey.Should().Be(firstTestCategory.DescriptionResourceKey);
        }

        [Fact]
        public async Task PostTest()
        {
            Category newCategory = new Category()
            {
                Id = Guid.NewGuid(),
                NameResourceKey = "testnew",
                DescriptionResourceKey = "testnew"
            };

            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync<Category>("/api/category", newCategory);

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            responseJson.ToLower().Should().Be(bool.TrueString.ToLower());


            HttpResponseMessage getResponse = await this.httpClient.GetAsync($"/api/category/{newCategory.Id}");

            getResponse.EnsureSuccessStatusCode();

            string getResponseJson = await getResponse.Content.ReadAsStringAsync();

            Category addedCategory = JsonConvert.DeserializeObject<Category>(getResponseJson);

            addedCategory.Id.Should().Be(newCategory.Id);
            addedCategory.NameResourceKey.Should().Be(newCategory.NameResourceKey);
            addedCategory.DescriptionResourceKey.Should().Be(newCategory.DescriptionResourceKey);

        }
    }
}
