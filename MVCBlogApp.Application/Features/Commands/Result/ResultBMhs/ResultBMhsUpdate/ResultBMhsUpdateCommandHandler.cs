using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate
{
    public class ResultBMhsUpdateCommandHandler : IRequestHandler<ResultBMhsUpdateCommandRequest, ResultBMhsUpdateCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMhsUpdateCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMhsUpdateCommandResponse> Handle(ResultBMhsUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ResultText != null && request.ResultText != "" && request.ResultText.Length > 2 && request.ResultText.Length < 351)
            {
                return await _resultIslemleriService.ResultBMhsUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanlara geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
