using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopCreate
{
    public class WorkshopCreateCommandValidator : AbstractValidator<WorkshopCreateCommandRequest>
    {
        public WorkshopCreateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen girilen degeri enaz 2 ve encok 250 karakter olacak şekilde giriniz.");

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

            RuleFor(x => x.Address)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Adres giriniz.");

            RuleFor(h => h.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir fiyat giriniz.")
                .InclusiveBetween(0, 100000000)
                .WithMessage("Lütfen fiyatı en az 0 olacak şekilde giriniz.");

            RuleFor(x => x.Description)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Açıklama giriniz.");

            RuleFor(x => x.WseducationId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Eğitim Tipi şeçiniz.");

            RuleFor(x => x.WstypeId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Seminer Kategori şeçiniz.");

            RuleFor(x => x.LangId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.StatusId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.NavigationId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Navigasyon şeçiniz.");
        }
    }
}
