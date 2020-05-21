using BlazorSample.Domain.Entities;
using BlazorSample.Domain.Interfaces.Repositories;
using BlazorSample.Infra.Data.Context;

namespace BlazorSample.Infra.Data.Repositories {
    public class UserRepository : Repository<User>, IUserRepository {
        public UserRepository (ApplicationDbContext dbContext) : base (dbContext) { }
    }
}