using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsUpdate
{
    public class ResultOptimumsUpdateCommandHandler : IRequestHandler<ResultOptimumsUpdateCommandRequest, ResultOptimumsUpdateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultOptimumsUpdateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultOptimumsUpdateCommandResponse> Handle(ResultOptimumsUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultOptimumsUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultOptimumsUpdateAsync(request);
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
