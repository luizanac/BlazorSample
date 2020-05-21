using System.Linq;
using BlazorSample.Domain.Core.Entities;
using BlazorSample.Domain.Validators.User;
using Microsoft.AspNetCore.Identity;

namespace BlazorSample.Domain.Entities {
    public class User : Entity {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }

        public User (string name, string email, string password) : base () {
            this.Name = name;
            this.Email = email;
            this.Password = HashPassword (password);

            Validate (this, new UserValidator ());
        }

        public User (string name, string email, string password, string role) : this (name, email, password) {

        }

        public User (string name, string email, string password, string[] roles) {

        }

        public string HashPassword (string value) {
            var hasher = new PasswordHasher<User> ();
            return hasher.HashPassword (this, value);
        }

        public bool BelongsToRole (string role) {
            return Roles.Contains (role);
        }

    }
}