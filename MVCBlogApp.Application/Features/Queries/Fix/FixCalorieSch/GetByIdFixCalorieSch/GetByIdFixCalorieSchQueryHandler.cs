using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch
{
    public class GetByIdFixCalorieSchQueryHandler : IRequestHandler<GetByIdFixCalorieSchQueryRequest, GetByIdFixCalorieSchQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixCalorieSchQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixCalorieSchQueryResponse> Handle(GetByIdFixCalorieSchQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixCalorieSchAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixCalorieSch = null,
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
