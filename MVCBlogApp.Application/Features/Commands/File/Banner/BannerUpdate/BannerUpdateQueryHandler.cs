using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerUpdate
{
    public class BannerUpdateQueryHandler : IRequestHandler<BannerUpdateQueryRequest, BannerUpdateQueryResponse>
    {
        private readonly IFileProcessService _fileProcessService;

        public BannerUpdateQueryHandler(IFileProcessService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }

        public async Task<BannerUpdateQueryResponse> Handle(BannerUpdateQueryRequest request, CancellationToken cancellationToken)
        {
            BannerUpdateQueryValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fileProcessService.BannerUpdateAsync(request);
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
