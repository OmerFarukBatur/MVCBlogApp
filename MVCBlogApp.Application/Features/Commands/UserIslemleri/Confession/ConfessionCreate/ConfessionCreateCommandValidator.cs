using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate
{
    public class ConfessionCreateCommandValidator : AbstractValidator<ConfessionCreateCommandRequest>
    {
        public ConfessionCreateCommandValidator()
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

            RuleFor(x => x.IsAprove)
               .NotNull()
               .WithMessage("Lütfen Yayınlansın mı ? alanından bir seçim yapınız."); 

            RuleFor(x => x.IsRead)
               .NotNull()
               .WithMessage("Lütfen Görüldü alanından bir seçim yapınız.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
