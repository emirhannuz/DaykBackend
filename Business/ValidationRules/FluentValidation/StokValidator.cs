using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StokValidator : AbstractValidator<Stok>
    {
        public StokValidator()
        {
            RuleFor(s => s.UrunId).NotNull();

            RuleFor(s => s.KayitYapanId).NotNull();

            RuleFor(s => s.Adet).NotNull();
            RuleFor(s => s.Adet).GreaterThanOrEqualTo(1);
        }
    }
}
