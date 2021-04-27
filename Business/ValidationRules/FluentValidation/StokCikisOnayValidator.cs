using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StokCikisOnayValidator : AbstractValidator<StokCikisOnay>
    {
        public StokCikisOnayValidator()
        {
            RuleFor(sco => sco.StokCikisId).NotEmpty();
            RuleFor(sco => sco.StokCikisId).NotNull();

            RuleFor(sco => sco.OnaylayanKullaniciId).NotEmpty();
            RuleFor(sco => sco.OnaylayanKullaniciId).NotNull();
        }
    }
}
