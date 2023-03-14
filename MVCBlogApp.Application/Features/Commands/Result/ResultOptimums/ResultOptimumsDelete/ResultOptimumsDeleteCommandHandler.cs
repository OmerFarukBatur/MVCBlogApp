using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsDelete
{
    public class ResultOptimumsDeleteCommandHandler : IRequestHandler<ResultOptimumsDeleteCommandRequest, ResultOptimumsDeleteCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultOptimumsDeleteCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultOptimumsDeleteCommandResponse> Handle(ResultOptimumsDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.ResultOptimumsDeleteAsync(request.Id);
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
