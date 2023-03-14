using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsCreate
{
    public class ResultOptimumsCreateCommandHandler : IRequestHandler<ResultOptimumsCreateCommandRequest, ResultOptimumsCreateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultOptimumsCreateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultOptimumsCreateCommandResponse> Handle(ResultOptimumsCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultOptimumsCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultOptimumsCreateAsync(request);
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
