using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.IUHome.Influencer
{
    public class InfluencerCommandHandler : IRequestHandler<InfluencerCommandRequest, InfluencerCommandResponse>
    {
        private readonly IUIHomeService _uiHomeService;

        public InfluencerCommandHandler(IUIHomeService uiHomeService)
        {
            _uiHomeService = uiHomeService;
        }

        public async Task<InfluencerCommandResponse> Handle(InfluencerCommandRequest request, CancellationToken cancellationToken)
        {
            InfluencerCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _uiHomeService.InfluencerAsync(request);
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
