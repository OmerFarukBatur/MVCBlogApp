using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate
{
    public class AppointmentCreateCommandValidator : AbstractValidator<AppointmentCreateCommandRequest>
    {
        public AppointmentCreateCommandValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Konu bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Konu enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MembersId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Danışan şeçiniz.");

            RuleFor(x => x.UserId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Diyetisyen şeçiniz.");

            RuleFor(x => x.AppointmentDate)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Tarihi giriniz.");

            RuleFor(x => x.AppointmentTime)
               .NotNull()
               .WithMessage("Lütfen bir Başlangıç Saati giriniz.");

            RuleFor(h => h.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir fiyat giriniz.")
                .InclusiveBetween(0, 100000000)
                .WithMessage("Lütfen fiyatı en az 0 olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Açıklama bölümünü doldurunuz.");
        }
    }
}
