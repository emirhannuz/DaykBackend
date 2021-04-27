using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StokCikisValidator : AbstractValidator<StokCikis>
    {
        public StokCikisValidator()
        {
            RuleFor(sc => sc.AfetzedeId).NotNull();


            RuleFor(sc => sc.UrunId).NotNull();

            RuleFor(sc => sc.Adet).NotNull();
            RuleFor(sc => sc.Adet).GreaterThanOrEqualTo(1);
        }
    }
}
