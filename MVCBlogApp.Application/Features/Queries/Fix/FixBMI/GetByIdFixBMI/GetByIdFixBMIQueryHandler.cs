using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI
{
    public class GetByIdFixBMIQueryHandler : IRequestHandler<GetByIdFixBMIQueryRequest, GetByIdFixBMIQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixBMIQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixBMIQueryResponse> Handle(GetByIdFixBMIQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixBMIAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixBMI = null,
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
