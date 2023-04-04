using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidCreate
{
    public class FixFeedPyramidCreateCommandHandler : IRequestHandler<FixFeedPyramidCreateCommandRequest, FixFeedPyramidCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixFeedPyramidCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixFeedPyramidCreateCommandResponse> Handle(FixFeedPyramidCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixFeedPyramidCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixFeedPyramidCreateAsync(request);
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
