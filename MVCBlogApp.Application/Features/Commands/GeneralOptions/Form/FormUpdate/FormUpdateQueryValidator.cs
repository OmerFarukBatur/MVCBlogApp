using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate
{
    public class FormUpdateQueryValidator : AbstractValidator<FormUpdateQueryRequest>
    {
        public FormUpdateQueryValidator()
        {
            RuleFor(x => x.FormName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Form Adı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Form Adı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Controller)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Controller bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Controller enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Action)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Action bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Action enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
