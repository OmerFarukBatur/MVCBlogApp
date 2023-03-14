using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetByIdResultPulse
{
    public class GetByIdResultPulseQueryHandler : IRequestHandler<GetByIdResultPulseQueryRequest, GetByIdResultPulseQueryResponse>
    {
        private readonly IResultIslemleriService _resultIslemleriService;

        public GetByIdResultPulseQueryHandler(IResultIslemleriService resultIslemleriService)
        {
            _resultIslemleriService = resultIslemleriService;
        }

        public async Task<GetByIdResultPulseQueryResponse> Handle(GetByIdResultPulseQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _resultIslemleriService.GetByIdResultPulseAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    ResultPulse = null,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
