using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate
{
    public class EventUpdateCommandValidator : AbstractValidator<EventUpdateCommandRequest>
    {
        public EventUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Başlık alanını boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen girilen Başlık degeri enaz 2 ve encok 250 karakter olacak şekilde giriniz.");

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

            RuleFor(x => x.EventCategoryId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Etkinlik Kategorisi seçiniz.");

            RuleFor(x => x.StatusId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
