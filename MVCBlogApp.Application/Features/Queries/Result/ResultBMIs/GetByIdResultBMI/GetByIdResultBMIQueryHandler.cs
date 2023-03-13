using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultBMIs.GetByIdResultBMI
{
    public class GetByIdResultBMIQueryHandler : IRequestHandler<GetByIdResultBMIQueryRequest, GetByIdResultBMIQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetByIdResultBMIQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetByIdResultBMIQueryResponse> Handle(GetByIdResultBMIQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.GetByIdResultBMIAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    ResultBMI = null,
                    State = false
                };
            }
        }
    }
}
