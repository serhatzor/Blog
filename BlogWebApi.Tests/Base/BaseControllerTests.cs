using Blog.Interfaces.Base;
using BlogWebApi.Base;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApi.Tests.Base
{
    public class BaseControllerTests<E, C, S>
        where E : BaseEntity , new()
        where C : BaseApiController<E>
        where S : class, IBaseService<E>
    {
        private E CreateEntity()
        {
            E entity = new E();
            entity.Id = Guid.NewGuid();

            return entity;
        }

        public virtual void ProviderIsNull()
        {
            Action action = () =>
            {
                try
                {
                    C sut = (C)Activator.CreateInstance(typeof(C), new object[] { null });
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }

            };

            action.Should().Throw<ArgumentNullException>().WithMessage("*service*");
        }

        public virtual void ProviderIsNotNull()
        {
            Action action = () =>
            {
                Mock<S> mockService = new Mock<S>();
                C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);
            };

            action.Should().NotThrow();
        }

        public virtual async Task GetAllReturnsSameAsWhatServiceReturns()
        {
            List<E> expectedEntities = new List<E>();

            expectedEntities.Add(CreateEntity());
            expectedEntities.Add(CreateEntity());
            expectedEntities.Add(CreateEntity());

            Mock<S> mockService = new Mock<S>();
            mockService.Setup(x => x.GetAsync()).Returns(() =>
            {
                return Task.FromResult(expectedEntities);
            });

            C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);

            IEnumerable<E> actualEntites = await sut.Get();

            actualEntites.Should().BeSameAs(expectedEntities);
        }

        public virtual async Task GetReturnsSameAsWhatServiceReturns()
        {
            Guid entityId = Guid.NewGuid();
            E expectedEntity = CreateEntity();

            Mock<S> mockService = new Mock<S>();
            mockService.Setup(x => x.GetByIdAsync(entityId)).Returns(() =>
            {
                return Task.FromResult(expectedEntity);
            });

            C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);

            E actualEntity = await sut.Get(entityId);

            actualEntity.Should().BeSameAs(expectedEntity);
        }


        public virtual async Task AddReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            E expectedEntity = CreateEntity();

            Mock<S> mockService = new Mock<S>();
            mockService.Setup(x => x.AddAsync(expectedEntity)).Returns(() =>
            {
                return Task.FromResult(expectedResult);
            });

            C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);

            bool actualResult = await sut.Post(expectedEntity);

            actualResult.Should().Be(expectedResult);
        }

        public virtual async Task DeleteReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            Guid entityId = Guid.NewGuid();

            Mock<S> mockService = new Mock<S>();
            mockService.Setup(x => x.RemoveByIdAsync(entityId)).Returns(() =>
            {
                return Task.FromResult(expectedResult);
            });

            C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);

            bool actualResult = await sut.Delete(entityId);

            actualResult.Should().Be(expectedResult);
        }

        public virtual async Task UpdateReturnsSameAsWhatServiceReturns(bool expectedResult)
        {
            E expectedEntity = CreateEntity();

            Mock<S> mockService = new Mock<S>();
            mockService.Setup(x => x.UpdateAsync(expectedEntity)).Returns(() =>
            {
                return Task.FromResult(expectedResult);
            });

            C sut = (C)Activator.CreateInstance(typeof(C), mockService.Object);

            bool actualResult = await sut.Put(expectedEntity);

            actualResult.Should().Be(expectedResult);
        }

    }
}
