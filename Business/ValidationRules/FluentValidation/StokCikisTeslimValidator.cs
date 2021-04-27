using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StokCikisTeslimValidator : AbstractValidator<StokCikisTeslim>
    {
        public StokCikisTeslimValidator()
        {
            RuleFor(sct => sct.StokCikisId).NotEmpty();
            RuleFor(sct => sct.StokCikisId).NotNull();

            RuleFor(sct => sct.TeslimEdenKullaniciId).NotEmpty();
            RuleFor(sct => sct.TeslimEdenKullaniciId).NotNull();
        }
    }
}
