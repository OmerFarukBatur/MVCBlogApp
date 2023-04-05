using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize
{
    public class GetByIdFixMealSizeQueryHandler : IRequestHandler<GetByIdFixMealSizeQueryRequest, GetByIdFixMealSizeQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixMealSizeQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixMealSizeQueryResponse> Handle(GetByIdFixMealSizeQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixMealSizeAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixMealSize = null,
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
