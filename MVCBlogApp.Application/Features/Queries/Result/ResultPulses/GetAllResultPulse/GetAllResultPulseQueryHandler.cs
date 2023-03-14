using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetAllResultPulse
{
    public class GetAllResultPulseQueryHandler : IRequestHandler<GetAllResultPulseQueryRequest, GetAllResultPulseQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetAllResultPulseQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetAllResultPulseQueryResponse> Handle(GetAllResultPulseQueryRequest request, CancellationToken cancellationToken)
        {
            return await _resultIslemleriService.GetAllResultPulseAsync();
        }
    }
}
