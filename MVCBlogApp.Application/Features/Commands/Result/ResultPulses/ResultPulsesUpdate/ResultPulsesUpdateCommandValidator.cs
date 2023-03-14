using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesUpdate
{
    public class ResultPulsesUpdateCommandValidator : AbstractValidator<ResultPulsesUpdateCommandRequest>
    {
        public ResultPulsesUpdateCommandValidator()
        {
            RuleFor(x => x.ResultMaxText)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen ResultMaxText bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen ResultMaxText enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.ResultMinText)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen ResultMinText bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen ResultMinText enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");
        }
    }
}
