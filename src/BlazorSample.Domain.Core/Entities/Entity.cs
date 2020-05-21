using System;
using BlazorSample.Domain.Core.Interfaces.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace BlazorSample.Domain.Core.Entities {
    public abstract class Entity : IEntity {
        public Guid Id { get; protected set; }
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<T> (T entity, AbstractValidator<T> validator) {
            ValidationResult = validator.Validate (entity);
            return Valid = ValidationResult.IsValid;
        }

        public override bool Equals (object obj) {
            var compareTo = obj as Entity;

            if (ReferenceEquals (this, compareTo)) return true;
            if (ReferenceEquals (null, compareTo)) return false;

            return Id.Equals (compareTo.Id);
        }

        public static bool operator == (Entity a, Entity b) {
            if (ReferenceEquals (a, null) && ReferenceEquals (b, null))
                return true;

            if (ReferenceEquals (a, null) || ReferenceEquals (b, null))
                return false;

            return a.Equals (b);
        }

        public static bool operator != (Entity a, Entity b) {
            return !(a == b);
        }

        public override int GetHashCode () {
            return (GetType ().GetHashCode () * 907) + Id.GetHashCode ();
        }

        public override string ToString () {
            return GetType ().Name + " [Id=" + Id + "]";
        }

        public bool IsValid () {
            throw new NotImplementedException ();
        }
    }
}