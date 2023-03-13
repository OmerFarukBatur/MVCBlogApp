using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsDelete
{
    public class ResultBMIsDeleteCommandHandler : IRequestHandler<ResultBMIsDeleteCommandRequest, ResultBMIsDeleteCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultBMIsDeleteCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultBMIsDeleteCommandResponse> Handle(ResultBMIsDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.ResultBMIsDeleteAsync(request.Id);
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
