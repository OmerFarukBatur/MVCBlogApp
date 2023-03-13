using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetAllResultBMI
{
    public class GetAllResultBMIQueryHandler : IRequestHandler<GetAllResultBMIQueryRequest, GetAllResultBMIQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetAllResultBMIQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetAllResultBMIQueryResponse> Handle(GetAllResultBMIQueryRequest request, CancellationToken cancellationToken)
        {
            return await _resultIslemleriService.GetAllResultBMIAsync();
        }
    }
}
