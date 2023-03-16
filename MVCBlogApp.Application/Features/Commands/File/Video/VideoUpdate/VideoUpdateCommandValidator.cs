using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.File.Video.VideoUpdate
{
    public class VideoUpdateCommandValidator : AbstractValidator<VideoUpdateCommandRequest>
    {
        public VideoUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Title alanını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(250)
                .WithMessage("Lütfen Title alanını enaz 2 ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.VideoUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen VideoUrl alanını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(500)
                .WithMessage("Lütfen VideoUrl alanını enaz 2 ençok 500 karakter olacak şekilde giriniz.");

            RuleFor(x => x.VideoEmbedCode)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen VideoEmbedCode alanını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(600)
                .WithMessage("Lütfen VideoEmbedCode alanını enaz 2 ençok 600 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen VideoEmbedCode alanını boş geçmeyiniz.");

            RuleFor(x => x.VideoCategoryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Video Kategory şeçiniz.");

            RuleFor(x => x.StatusId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
