using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Admin.Calendar.EventDateTimeUpdate
{
    public class EventDateTimeUpdateCommandValidator : AbstractValidator<EventDateTimeUpdateCommandRequest>
    {
        public EventDateTimeUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.StartDate)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Tarihi giriniz.");

            RuleFor(x => x.StartTime)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Saati giriniz.");

            RuleFor(x => x.FinishDate)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Tarihi giriniz.");

            RuleFor(x => x.FinishTime)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Saati giriniz.");
        }
    }
}
