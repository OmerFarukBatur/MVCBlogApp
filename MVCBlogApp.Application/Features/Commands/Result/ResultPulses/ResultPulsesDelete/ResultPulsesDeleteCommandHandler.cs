using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesDelete
{
    public class ResultPulsesDeleteCommandHandler : IRequestHandler<ResultPulsesDeleteCommandRequest, ResultPulsesDeleteCommandResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public ResultPulsesDeleteCommandHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<ResultPulsesDeleteCommandResponse> Handle(ResultPulsesDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.ResultPulsesDeleteAsync(request.Id);
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
