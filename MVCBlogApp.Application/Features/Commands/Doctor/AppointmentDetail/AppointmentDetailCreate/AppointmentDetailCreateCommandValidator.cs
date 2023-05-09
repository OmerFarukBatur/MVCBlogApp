using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailCreate
{
    public class AppointmentDetailCreateCommandValidator : AbstractValidator<AppointmentDetailCreateCommandRequest>
    {
        public AppointmentDetailCreateCommandValidator()
        {
            RuleFor(x => x.MembersId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Danışan şeçiniz.");

            RuleFor(x => x.UserId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Doktor şeçiniz.");

            RuleFor(x => x.AppointmentId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Danışan Randevu şeçiniz.");            

            RuleFor(h => h.Weight)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Kilo giriniz.")
                .InclusiveBetween(0, 1000)
                .WithMessage("Lütfen kilo en az 0 en çok 1000 olacak şekilde giriniz.");

            RuleFor(h => h.Size)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Boy giriniz.")
               .InclusiveBetween(0, 600)
               .WithMessage("Lütfen boy en az 0 en çok 600 olacak şekilde giriniz.");

            RuleFor(h => h.OilRate)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Yağ Oranı giriniz.")
               .InclusiveBetween(0, 100)
               .WithMessage("Lütfen Yağ Oranı en az 0 en çok 100 olacak şekilde giriniz.");

            RuleFor(x => x.Diagnosis)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Teşhis giriniz.");

            RuleFor(x => x.History)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Hasta Hikayesi giriniz.");

            RuleFor(x => x.Treatment)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Tedavi/Çözüm giriniz.");
        }
    }
}
