using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Test.BMICalculate
{
    public class BMICalculateQueryHandler : IRequestHandler<BMICalculateQueryRequest, BMICalculateQueryResponse>
    {
        private readonly IUIOtherService _service;

        public BMICalculateQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<BMICalculateQueryResponse> Handle(BMICalculateQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.BMICalculateAsync();
        }
    }
}
