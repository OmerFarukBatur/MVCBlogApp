using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate
{
    public class ResultBMIsUpdateCommandHandler : IRequestHandler<ResultBMIsUpdateCommandRequest, ResultBMIsUpdateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMIsUpdateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMIsUpdateCommandResponse> Handle(ResultBMIsUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ResultBMIsUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _resultIslemleriService.ResultBMIsUpdateAsync(request);
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
