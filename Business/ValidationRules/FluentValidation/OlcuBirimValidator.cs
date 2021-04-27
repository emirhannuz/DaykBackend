using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OlcuBirimValidator : AbstractValidator<OlcuBirim>
    {
        public OlcuBirimValidator()
        {
            RuleFor(ob => ob.OlcuAdi).NotEmpty();
            RuleFor(ob => ob.OlcuAdi).NotNull();
            RuleFor(ob => ob.OlcuAdi).MaximumLength(250);

        }
    }
}
