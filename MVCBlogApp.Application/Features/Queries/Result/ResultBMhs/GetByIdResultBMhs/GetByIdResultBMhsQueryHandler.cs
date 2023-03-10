using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMhs.GetByIdResultBMhs
{
    public class GetByIdResultBMhsQueryHandler : IRequestHandler<GetByIdResultBMhsQueryRequest, GetByIdResultBMhsQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetByIdResultBMhsQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetByIdResultBMhsQueryResponse> Handle(GetByIdResultBMhsQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.GetByIdResultBMhsAsync(request.Id);
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
