using BlazorSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample.Infra.Data.Context {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext (DbContextOptions options) : base (options) {

        }

        public DbSet<User> Users { get; set; }
    }
}