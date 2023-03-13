using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate
{
    public class ResultBMIsUpdateCommandValidator : AbstractValidator<ResultBMIsUpdateCommandRequest>
    {
        public ResultBMIsUpdateCommandValidator() 
        {
            RuleFor(x => x.IntervalDescription)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen IntervalDescription bölümünü doldurunuz.")
               .MaximumLength(400)
               .MinimumLength(2)
               .WithMessage("Lütfen IntervalDescriptionı enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(s => s.IntervalMin)
                .NotEmpty()
                .NotNull()
                .MaximumLength(6)
                .MinimumLength(1)
                .WithMessage("Lütfen 0 ile 1000 arasında IntervalMin değeri giriniz.");

            RuleFor(s => s.IntervalMax)
               .NotEmpty()
               .NotNull()
               .MaximumLength(6)
               .MinimumLength(1)
               .WithMessage("Lütfen 0 ile 1000 arasında IntervalMax değeri giriniz.");
        }
    }
}
