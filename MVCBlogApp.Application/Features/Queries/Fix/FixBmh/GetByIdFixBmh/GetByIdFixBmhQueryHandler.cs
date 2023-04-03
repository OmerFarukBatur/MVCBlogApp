using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh
{
    public class GetByIdFixBmhQueryHandler : IRequestHandler<GetByIdFixBmhQueryRequest, GetByIdFixBmhQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixBmhQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixBmhQueryResponse> Handle(GetByIdFixBmhQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixBmhAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixBmh = null,
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
