using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.IUHome.Danisan
{
    public class DanisanConfessionCreateCommandHandler : IRequestHandler<DanisanConfessionCreateCommandRequest, DanisanConfessionCreateCommandResponse>
    {
        private readonly IUIHomeService _homeService;

        public DanisanConfessionCreateCommandHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<DanisanConfessionCreateCommandResponse> Handle(DanisanConfessionCreateCommandRequest request, CancellationToken cancellationToken)
        {
            DanisanConfessionCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _homeService.DanisanConfessionCreateAsync(request);
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
