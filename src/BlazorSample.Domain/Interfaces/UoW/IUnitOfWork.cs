using System;
using System.Threading.Tasks;
using BlazorSample.Domain.Interfaces.Repositories;

namespace BlazorSample.Domain.Interfaces.UoW {
    public interface IUnitOfWork : IDisposable {
        IUserRepository UserRepository { get; }
        Task Commit ();
    }
}