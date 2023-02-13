﻿using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Home.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad'ı boş geçmeyiniz.")
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("Lütfen Adınızı minimum 2 karakter maksimum 50 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Soyad'ı boş geçmeyiniz.")
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("Lütfen Soyadınızı minimum 2 karakter maksimum 50 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Şifre'yi boş geçmeyiniz.")
                .MinimumLength(6)
                .WithMessage("Lütfen şifrenizi enaz 6 karakter olacak şekilde giriniz.");
        }
    }
}
