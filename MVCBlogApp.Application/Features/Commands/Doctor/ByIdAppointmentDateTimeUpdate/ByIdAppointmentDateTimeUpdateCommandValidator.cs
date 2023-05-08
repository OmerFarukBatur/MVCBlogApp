using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.ByIdAppointmentDateTimeUpdate
{
    public class ByIdAppointmentDateTimeUpdateCommandValidator : AbstractValidator<ByIdAppointmentDateTimeUpdateCommandRequest>
    {
        public ByIdAppointmentDateTimeUpdateCommandValidator()
        {
            RuleFor(x => x.AppointmentDate)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Tarihi giriniz.");

            RuleFor(x => x.AppointmentTime)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Saati giriniz.");
        }
    }
}
