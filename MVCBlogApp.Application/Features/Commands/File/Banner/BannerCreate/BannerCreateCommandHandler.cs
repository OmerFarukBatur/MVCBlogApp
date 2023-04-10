using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerCreate
{
    public class BannerCreateCommandHandler : IRequestHandler<BannerCreateCommandRequest, BannerCreateCommandResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public BannerCreateCommandHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<BannerCreateCommandResponse> Handle(BannerCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BannerCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.BannerCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
