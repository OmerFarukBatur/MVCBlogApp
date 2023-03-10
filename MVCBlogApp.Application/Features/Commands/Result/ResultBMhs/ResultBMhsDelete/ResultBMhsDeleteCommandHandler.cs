using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete
{
    public class ResultBMhsDeleteCommandHandler : IRequestHandler<ResultBMhsDeleteCommandRequest, ResultBMhsDeleteCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMhsDeleteCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMhsDeleteCommandResponse> Handle(ResultBMhsDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.ResultBMhsDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
