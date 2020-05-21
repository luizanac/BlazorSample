using BlazorSample.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorSample.Domain.Entities {
    public abstract class User : Entity {
        public string Name { get; set; }
        public string Email { get; set; }

        private string _password;
        public string Password { get => _password; set { _password = HashPassword (value); } }

        public string HashPassword (string value) {
            var hasher = new PasswordHasher<User> ();
            return hasher.HashPassword (this, value);
        }

    }
}