using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetByIdFixFeedPyramid
{
    public class GetByIdFixFeedPyramidQueryHandler : IRequestHandler<GetByIdFixFeedPyramidQueryRequest, GetByIdFixFeedPyramidQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetByIdFixFeedPyramidQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetByIdFixFeedPyramidQueryResponse> Handle(GetByIdFixFeedPyramidQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _fixService.GetByIdFixFeedPyramidAsync(request.Id);
            }
            else
            {
                return new()
                {
                    FixFeedPyramid = null,
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
