using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Test.BMICalculateCreate
{
    public class BMICalculateCreateCommandValidator : AbstractValidator<BMICalculateCreateCommandRequest>
    {
        public BMICalculateCreateCommandValidator()
        {
            RuleFor(x => x.CalcBMI.NameSurname)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Ad'ı boş geçmeyiniz.")
               .MaximumLength(250)
               .WithMessage("Lütfen Adı ve Soyadınızı maksimum 200 karakter olacak şekilde giriniz.");

            RuleFor(x => x.CalcBMI.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .MaximumLength(250)
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");


            RuleFor(x => x.CalcBMI.Size)
                .InclusiveBetween(100, 500)
                .WithMessage("Lütfen boy değeri 100 ile 500 arasında olacak şekilde giriniz.");

            RuleFor(x => x.CalcBMI.Weight)
                .InclusiveBetween(20, 1000)
                .WithMessage("Lütfen kilo değeri 20 ile 1000 arasında olacak şekilde giriniz.");

            RuleFor(x => x.CalcBMI.Age)
                .InclusiveBetween(10, 120)
                .WithMessage("Lütfen yaş değeri 10 ile 120 arasında olacak şekilde giriniz.");
        }
    }
}
