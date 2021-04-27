using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AfetzedeValidator : AbstractValidator<Afetzede>
    {
        public AfetzedeValidator()
        {
            RuleFor(a => a.TcYuNo).NotEmpty();
            RuleFor(a => a.TcYuNo).NotNull();
            RuleFor(a => a.TcYuNo).MinimumLength(11);
            RuleFor(a => a.TcYuNo).MaximumLength(11);

            RuleFor(a => a.Adi).NotEmpty();
            RuleFor(a => a.Adi).NotNull();
            RuleFor(a => a.Adi).MinimumLength(2);
            RuleFor(a => a.Adi).MaximumLength(50);

            RuleFor(a => a.Soyadi).NotEmpty();
            RuleFor(a => a.Soyadi).NotNull();
            RuleFor(a => a.Soyadi).MinimumLength(2);
            RuleFor(a => a.Soyadi).MaximumLength(50);

            RuleFor(a => a.CepTelefonuNumarasi).NotEmpty();
            RuleFor(a => a.CepTelefonuNumarasi).NotNull();
            RuleFor(a => a.CepTelefonuNumarasi).MinimumLength(11);
            RuleFor(a => a.CepTelefonuNumarasi).MaximumLength(11);

            RuleFor(a => a.AcikAdres).NotEmpty();
            RuleFor(a => a.AcikAdres).NotNull();

        }
    }
}
