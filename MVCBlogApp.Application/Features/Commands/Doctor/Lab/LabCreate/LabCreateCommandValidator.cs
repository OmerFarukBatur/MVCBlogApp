using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabCreate
{
    public class LabCreateCommandValidator : AbstractValidator<LabCreateCommandRequest>
    {
        public LabCreateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Tetkik Talep Başlığı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Tetkik Talep Başlığı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Tetkik Talep Açıklaması bölümünü doldurunuz.")
                .MaximumLength(500)
                .MinimumLength(2)
                .WithMessage("Lütfen Tetkik Talep Açıklaması enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LabDateTime)
               .NotNull()
               .WithMessage("Lütfen bir Tetkik İstek Tarihi giriniz.");

            RuleFor(x => x.AppointmentDetailId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir tane Danışan Raporu seçiniz.");

            RuleFor(x => x.UsersId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Diyetisyen şeçiniz.");

            RuleForEach(s => s.ExaminationId)
                .Must(
                        (f, v) =>
                        {
                            if (v > 0)
                                return true;
                            return false;
                        }
                        )
                .WithMessage("Lütfen bir İstenen Tetkik seçiniz.");            
        }
    }
}
