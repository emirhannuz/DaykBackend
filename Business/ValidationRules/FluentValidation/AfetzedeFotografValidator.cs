using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AfetzedeFotografValidator : AbstractValidator<AfetzedeFotograf>
    {
        public AfetzedeFotografValidator()
        {
            RuleFor(af => af.AfetzedeId).NotEmpty();
            RuleFor(af => af.AfetzedeId).NotNull();
            RuleFor(af => af.FotografYolu).NotEmpty();
            RuleFor(af => af.FotografYolu).NotNull();

        }
    }
}
