using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate
{
    public class OurTeamUpdateCommandValidator : AbstractValidator<OurTeamUpdateCommandRequest>
    {
        public OurTeamUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Başlık alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Başlığı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.NameSurname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad Soyad alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Ad Soyad enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Bio)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Bio alanını doldurunuz.")
                .MaximumLength(400)
                .MinimumLength(2)
                .WithMessage("Lütfen Bio enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
