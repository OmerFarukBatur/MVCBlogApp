using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidUpdate
{
    public class FixFeedPyramidUpdateCommandHandler : IRequestHandler<FixFeedPyramidUpdateCommandRequest, FixFeedPyramidUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixFeedPyramidUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixFeedPyramidUpdateCommandResponse> Handle(FixFeedPyramidUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixFeedPyramidUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixFeedPyramidUpdateAsync(request);
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
