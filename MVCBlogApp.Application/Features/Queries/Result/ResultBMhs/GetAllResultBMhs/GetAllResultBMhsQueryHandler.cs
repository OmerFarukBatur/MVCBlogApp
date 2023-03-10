using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetAllResultBMhs
{
    public class GetAllResultBMhsQueryHandler : IRequestHandler<GetAllResultBMhsQueryRequest, GetAllResultBMhsQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetAllResultBMhsQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetAllResultBMhsQueryResponse> Handle(GetAllResultBMhsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _resultIslemleriService.GetAllResultBMhsAsync();
        }
    }
}
