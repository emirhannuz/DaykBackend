using Core.Entites.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(250);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).MaximumLength(250);

            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Username).NotNull();
            RuleFor(u => u.Username).MinimumLength(3);
            RuleFor(u => u.Username).MaximumLength(50);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).MaximumLength(250);

            RuleFor(u => u.PhoneNumber).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotNull();
            RuleFor(u => u.PhoneNumber).MinimumLength(11);
            RuleFor(u => u.PhoneNumber).MaximumLength(11);

            RuleFor(u => u.TcNo).NotEmpty();
            RuleFor(u => u.TcNo).NotNull();
            RuleFor(u => u.TcNo).MinimumLength(11);
            RuleFor(u => u.TcNo).MaximumLength(11);

            RuleFor(u => u.Address).NotEmpty();
            RuleFor(u => u.Address).NotNull();


        }
    }
}
