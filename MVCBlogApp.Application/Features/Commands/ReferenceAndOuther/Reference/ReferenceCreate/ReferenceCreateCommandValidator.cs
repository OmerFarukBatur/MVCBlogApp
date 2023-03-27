using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate
{
    public class ReferenceCreateCommandValidator : AbstractValidator<ReferenceCreateCommandRequest>
    {
        public ReferenceCreateCommandValidator()
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
                .WithMessage("Lütfen UrlLink enaz 2 ve ençok 300 karakter olacak şekilde giriniz.");            

            RuleFor(x => x.FormFile)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Fotoğraf yükleyiniz.");
           
            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
