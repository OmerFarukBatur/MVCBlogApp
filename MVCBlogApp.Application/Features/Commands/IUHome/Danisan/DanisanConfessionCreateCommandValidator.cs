using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.IUHome.Danisan
{
    public class DanisanConfessionCreateCommandValidator : AbstractValidator<DanisanConfessionCreateCommandRequest>
    {
        public DanisanConfessionCreateCommandValidator()
        {
            RuleFor(x => x.MemberConfession)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen Danışan İtirafı bölümünü doldurunuz.");

            RuleFor(x => x.MemberName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Danışan bölümünü doldurunuz.");

            RuleFor(x => x.IsVisible)
               .NotNull()
               .WithMessage("Lütfen İsim görünsün mü ? alanından bir seçim yapınız.");
        }
    }
}
