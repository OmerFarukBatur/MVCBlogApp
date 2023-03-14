using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesUpdate
{
    public class ResultPulsesUpdateCommandHandler : IRequestHandler<ResultPulsesUpdateCommandRequest, ResultPulsesUpdateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultPulsesUpdateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultPulsesUpdateCommandResponse> Handle(ResultPulsesUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultPulsesUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultPulsesUpdateAsync(request);
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
