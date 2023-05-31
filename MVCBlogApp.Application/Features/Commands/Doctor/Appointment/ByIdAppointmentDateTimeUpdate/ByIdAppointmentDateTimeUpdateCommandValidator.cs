using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate
{
    public class ByIdAppointmentDateTimeUpdateCommandValidator : AbstractValidator<ByIdAppointmentDateTimeUpdateCommandRequest>
    {
        public ByIdAppointmentDateTimeUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.AppointmentDate)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Tarihi giriniz.");

            RuleFor(x => x.AppointmentTime)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Saati giriniz.");
        }
    }
}
