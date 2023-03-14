using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetAllResultOptimums
{
    public class GetAllResultOptimumsQueryHandler : IRequestHandler<GetAllResultOptimumsQueryRequest, GetAllResultOptimumsQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetAllResultOptimumsQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetAllResultOptimumsQueryResponse> Handle(GetAllResultOptimumsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _resultIslemleriService.GetAllResultOptimumsAsync();
        }
    }
}
