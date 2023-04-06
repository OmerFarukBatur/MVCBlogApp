using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetByIdFixPulse
{
    public class GetByIdFixPulseQueryHandler : IRequestHandler<GetByIdFixPulseQueryRequest, GetByIdFixPulseQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixPulseQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixPulseQueryResponse> Handle(GetByIdFixPulseQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixPulseAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixPulse = null,
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
