using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsCreate
{
    public class ResultBMIsCreateCommandHandler : IRequestHandler<ResultBMIsCreateCommandRequest, ResultBMIsCreateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMIsCreateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMIsCreateCommandResponse> Handle(ResultBMIsCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultBMIsCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultBMIsCreateAsync(request);
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
