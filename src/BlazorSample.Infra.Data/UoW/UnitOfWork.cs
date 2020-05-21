using System.Threading.Tasks;
using BlazorSample.Domain.Interfaces.Repositories;
using BlazorSample.Domain.Interfaces.UoW;
using BlazorSample.Infra.Data.Context;
using BlazorSample.Infra.Data.Repositories;

namespace BlazorSample.Infra.Data.UoW {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext _dbContext;
        private IUserRepository _userRepository;

        public UnitOfWork (ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository (_dbContext);

        public async Task Commit () {
            await _dbContext.SaveChangesAsync ();
        }

        public void Dispose () {
            _dbContext.Dispose ();
        }
    }
}