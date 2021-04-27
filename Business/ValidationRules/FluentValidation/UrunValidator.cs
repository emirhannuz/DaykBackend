using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UrunValidator : AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(u => u.TurId).NotNull();

            RuleFor(u => u.UrunAdi).NotEmpty();
            RuleFor(u => u.UrunAdi).NotNull();
            RuleFor(u => u.UrunAdi).MinimumLength(2);
            RuleFor(u => u.UrunAdi).MaximumLength(250);

            RuleFor(u => u.OlcuBirimId).NotEmpty();
            RuleFor(u => u.OlcuBirimId).NotNull();
        }
    }
}
