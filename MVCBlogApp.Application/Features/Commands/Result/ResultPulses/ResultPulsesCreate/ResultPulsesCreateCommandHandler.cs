using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesCreate
{
    public class ResultPulsesCreateCommandHandler : IRequestHandler<ResultPulsesCreateCommandRequest, ResultPulsesCreateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultPulsesCreateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultPulsesCreateCommandResponse> Handle(ResultPulsesCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultPulsesCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultPulsesCreateAsync(request);
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
