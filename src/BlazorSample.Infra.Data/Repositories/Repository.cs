using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSample.Domain.Core.Entities;
using BlazorSample.Domain.Interfaces.Repositories;
using BlazorSample.Infra.Data.Context;
using Luizanac.Utils.Extensions;
using Luizanac.Utils.Extensions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample.Infra.Data.Repositories {
    public class Repository<T> : IRepository<T> where T : Entity {
        protected readonly ApplicationDbContext DbContext;
        protected readonly DbSet<T> DbSet;
        public Repository (ApplicationDbContext dbContext) {
            DbContext = dbContext;
            DbSet = DbContext.Set<T> ();
        }
        public virtual async Task Create (T entity) {
            await DbSet.AddAsync (entity);
        }
        public virtual void Update (T entity) {
            DbSet.Attach (entity);
            DbContext.Entry (entity).State = EntityState.Modified;
        }
        public virtual void Remove (T entity) {
            DbSet.Remove (entity);
        }
        public virtual async Task<IList<T>> GetAll () {
            return await DbSet.ToListAsync ();
        }
        public virtual async Task<IPagination<IList<T>>> GetAllPaginated (int page, int size) {
            return await DbSet.Paginate (page, size);
        }
        public virtual async Task<T> GetById (Guid id) {
            return await DbSet.SingleOrDefaultAsync (e => e.Id == id);
        }
    }
}