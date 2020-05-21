using FluentValidation;

namespace BlazorSample.Domain.Validators.User {
    public class UserValidator : AbstractValidator<Entities.User> {
        public UserValidator () {
            RuleFor (c => c.Name)
                .NotEmpty ().WithMessage ("Please ensure you have entered the Name")
                .Length (2, 150).WithMessage ("The Name must have between 2 and 150 characters");

            RuleFor (c => c.Email)
                .NotEmpty ()
                .EmailAddress ();
        }
    }
}