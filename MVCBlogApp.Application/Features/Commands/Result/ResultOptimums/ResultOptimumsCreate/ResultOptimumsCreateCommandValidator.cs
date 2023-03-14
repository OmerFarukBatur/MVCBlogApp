using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsCreate
{
    public class ResultOptimumsCreateCommandValidator : AbstractValidator<ResultOptimumsCreateCommandRequest>
    {
        public ResultOptimumsCreateCommandValidator()
        {
            RuleFor(x => x.Result1text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Result1text bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen Result1text enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Result2text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Result2text bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen Result2text enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Result3text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Result3text bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen Result3text enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Result4text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Result4text bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen Result4text enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");
        }
    }
}
