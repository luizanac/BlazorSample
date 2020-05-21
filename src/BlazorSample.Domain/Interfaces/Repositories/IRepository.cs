using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSample.Domain.Core.Entities;
using Luizanac.Utils.Extensions.Interfaces;

namespace BlazorSample.Domain.Interfaces.Repositories {
    public interface IRepository<T> where T : Entity {
        Task<T> GetById (Guid id);
        Task<IList<T>> GetAll ();
        Task<IPagination<IList<T>>> GetAllPaginated (int page, int size);
        Task Create (T t);
        void Update (T t);
        void Remove (T t);
    }
}