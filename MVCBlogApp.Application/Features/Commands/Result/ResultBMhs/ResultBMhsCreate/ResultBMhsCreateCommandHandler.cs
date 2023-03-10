using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate
{
    public class ResultBMhsCreateCommandHandler : IRequestHandler<ResultBMhsCreateCommandRequest, ResultBMhsCreateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMhsCreateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMhsCreateCommandResponse> Handle(ResultBMhsCreateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ResultText != null && request.ResultText != "" && request.ResultText.Length > 2 && request.ResultText.Length < 351)
            {
                return await _resultIslemleriService.ResultBMhsCreateAsync(request);
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
