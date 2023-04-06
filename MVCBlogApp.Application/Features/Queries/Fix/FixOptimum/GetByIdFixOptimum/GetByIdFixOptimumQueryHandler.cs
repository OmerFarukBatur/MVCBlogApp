using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetByIdFixOptimum
{
    public class GetByIdFixOptimumQueryHandler : IRequestHandler<GetByIdFixOptimumQueryRequest, GetByIdFixOptimumQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixOptimumQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixOptimumQueryResponse> Handle(GetByIdFixOptimumQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixOptimumAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixOptimum = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
