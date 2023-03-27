using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate
{
    public class ReferenceUpdateCommandValidator : AbstractValidator<ReferenceUpdateCommandRequest>
    {
        public ReferenceUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Title alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Title enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.UrlLink)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen UrlLink alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen UrlLink enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
