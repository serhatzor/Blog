using Blog.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApi.Base
{
    public abstract class BaseApiController<T> : ControllerBase where T :  BaseEntity
    {
        private readonly IBaseService<T> service;
        public BaseApiController(IBaseService<T> service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public virtual Task<List<T>> Get()
        {
            return service.GetAsync();
        }

        public virtual Task<T> Get(Guid id)
        {
            return service.GetByIdAsync(id);
        }

        public virtual Task<bool> Post(T entity)
        {
            return service.AddAsync(entity);
        }

        public virtual Task<bool> Put(T entity)
        {
            return service.UpdateAsync(entity);
        }

        public virtual Task<bool> Delete(Guid id)
        {
            return service.RemoveByIdAsync(id);
        }
    }
}