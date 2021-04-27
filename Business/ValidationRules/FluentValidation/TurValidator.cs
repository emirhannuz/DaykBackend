using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TurValidator : AbstractValidator<Tur>
    {
        public TurValidator()
        {
            RuleFor(t => t.TurAdi).NotEmpty();
            RuleFor(t => t.TurAdi).NotNull();
            RuleFor(t => t.TurAdi).MinimumLength(2);
            RuleFor(t => t.TurAdi).MaximumLength(250);

        }
    }
}
