using Blog.Interfaces.Base;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReassureTest;
using FluentAssertions;
using System.Net.Http.Json;

namespace BlogWebApi.Integration.Tests.Base
{
    public abstract class BaseControllerTests<E, S, F>
        where E : BaseEntity
        where S : class, IBaseService<E>
        where F : class, S
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly string apiRoute;
        private readonly List<E> rootEntities;

        public BaseControllerTests(WebApplicationFactory<Startup> webApplicationFactory, string apiRoute, List<E> rootEntities)
        {
            this.webApplicationFactory = webApplicationFactory;
            this.apiRoute = $"/api/{apiRoute}";
            this.rootEntities = rootEntities;

            this.webApplicationFactory.Server.BaseAddress = new Uri("http://localhost/");
            this.webApplicationFactory = this.webApplicationFactory.WithWebHostBuilder((builder) =>
            {
                builder.ConfigureServices((services) =>
                {
                    services.AddScoped<S, F>();
                });
            });
            httpClient = this.webApplicationFactory.CreateClient();
        }

        public abstract E CreateNewEntity();
        public abstract string GetIsStringForGetAll();
        public abstract string GetIsStringForGetById();
        public abstract string GetIsStringForPost();
        public abstract string GetIsStringForUpdate();

        private async Task<string> GetAsync(string apiRoute)
        {
            HttpResponseMessage response = await this.httpClient.GetAsync(apiRoute);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }

        public virtual async Task GetAllTest()
        {
            string responseJson = await GetAsync(apiRoute);

            List<E> actualEntites = JsonConvert.DeserializeObject<List<E>>(responseJson);

            #region FluentAssertions
            actualEntites.Should().BeEquivalentTo(rootEntities);
            #endregion

            #region ReassureTest 
            actualEntites.Is(GetIsStringForGetAll());
            #endregion
        }

        public virtual async Task GetByIdTest()
        {
            E firstEntity = rootEntities[0];

            string responseJson = await GetAsync($"{apiRoute}/{firstEntity.Id}");

            E actualEntity = JsonConvert.DeserializeObject<E>(responseJson);

            #region FluentAssertions
            actualEntity.Should().BeEquivalentTo(firstEntity);
            #endregion

            #region ReassureTest 
            actualEntity.Is(GetIsStringForGetById());
            #endregion
        }


        public virtual async Task PostTest()
        {
            E newEntity = CreateNewEntity();

            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(apiRoute, newEntity);

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            responseJson.ToLower().Should().Be(bool.TrueString.ToLower());

            string getResponseJson = await GetAsync($"{apiRoute}/{newEntity.Id}");

            E addedEntity = JsonConvert.DeserializeObject<E>(getResponseJson);

            #region FluentAssertions
            addedEntity.Should().BeEquivalentTo(newEntity);
            #endregion

            #region ReassureTest
            addedEntity.Is(GetIsStringForPost());
            #endregion
        }

        public virtual async Task UpdateTest()
        {
            E firstEntity = rootEntities[0];

            E updatedEntity = CreateNewEntity();

            updatedEntity.Id = firstEntity.Id;

            HttpResponseMessage response = await this.httpClient.PutAsJsonAsync(apiRoute, updatedEntity);

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            responseJson.ToLower().Should().Be(bool.TrueString.ToLower());

            string getResponseJson = await GetAsync($"{apiRoute}/{updatedEntity.Id}");

            E actualEntity = JsonConvert.DeserializeObject<E>(getResponseJson);

            #region FluentAssertions
            actualEntity.Should().BeEquivalentTo(updatedEntity);
            #endregion

            #region ReassureTest
            actualEntity.Is(GetIsStringForUpdate());
            #endregion
        }

        public virtual async Task RemoveTest()
        {
            E firstEntity = rootEntities[0];

            HttpResponseMessage response = await this.httpClient.DeleteAsync($"{apiRoute}/{firstEntity.Id}");

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            responseJson.ToLower().Should().Be(bool.TrueString.ToLower());

            string getResponseJson = await GetAsync($"{apiRoute}/{firstEntity.Id}");

            E actualEntity = JsonConvert.DeserializeObject<E>(getResponseJson);

            actualEntity.Should().BeNull();
        }
    }
}