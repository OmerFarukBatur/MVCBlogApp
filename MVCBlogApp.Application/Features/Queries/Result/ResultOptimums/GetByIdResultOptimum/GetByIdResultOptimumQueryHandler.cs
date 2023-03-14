using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetByIdResultOptimum
{
    public class GetByIdResultOptimumQueryHandler : IRequestHandler<GetByIdResultOptimumQueryRequest, GetByIdResultOptimumQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetByIdResultOptimumQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetByIdResultOptimumQueryResponse> Handle(GetByIdResultOptimumQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.GetByIdResultOptimumAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz.",
                    ResultOptimum = null
                };
            }
        }
    }
}
