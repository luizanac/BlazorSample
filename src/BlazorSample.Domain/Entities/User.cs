using System;
using System.Collections.Generic;
using System.Linq;
using BlazorSample.Domain.Core.Entities;
using BlazorSample.Domain.Validators.User;
using Microsoft.AspNetCore.Identity;

namespace BlazorSample.Domain.Entities {
    public class User : Entity {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public IList<string> Roles { get; set; }

        //Empty constructor for ef
        public User () { }

        public User (string name, string email, string password) : base () {
            this.Name = name;
            this.Email = email;
            this.Password = HashPassword (password);

            Validate (this, new UserValidator ());
        }

        public User (string name, string email, string password, string role) : this (name, email, password) {
            if (role == null)
                throw new ArgumentNullException ("role", "role cannot be null");

            AddRole (role);
        }

        public User (string name, string email, string password, string[] roles) : this (name, email, password) {
            if (roles == null)
                throw new ArgumentNullException ("roles", "roles cannot be null");

            foreach (var role in roles)
                AddRole (role);
        }

        public string HashPassword (string value) {
            var hasher = new PasswordHasher<User> ();
            return hasher.HashPassword (this, value);
        }

        public IList<string> AddRole (string role) {
            if (Roles == null)
                Roles = new List<string> ();

            if (!BelongsToRole (role))
                Roles.Add (role);

            return Roles;
        }

        public IList<string> RemoveRole (string role) {
            if (Roles != null && BelongsToRole (role))
                Roles.Remove (role);

            return Roles;
        }

        public bool BelongsToRole (string role) {
            if (Roles == null)
                return false;

            return Roles.Contains (role);
        }

    }
}