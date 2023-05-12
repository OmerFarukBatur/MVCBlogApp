using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate
{
    public class DietListUpdateCommandValidator : AbstractValidator<DietListUpdateCommandRequest>
    {
        public DietListUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.AppointmentDetailId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Danışan Raporu şeçiniz.");

            RuleFor(x => x.DaysId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Gün şeçiniz.");

            RuleFor(x => x.MealId)
               .NotNull()
               .WithMessage("Lütfen bir Öğün seçiniz.");

            RuleFor(x => x.TimeInterval)
               .NotNull()
               .WithMessage("Lütfen bir Öğün Saati giriniz.");
        }
    }
}
