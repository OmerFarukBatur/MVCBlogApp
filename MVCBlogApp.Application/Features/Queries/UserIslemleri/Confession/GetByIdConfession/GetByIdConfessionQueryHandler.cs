using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetByIdConfession
{
    public class GetByIdConfessionQueryHandler : IRequestHandler<GetByIdConfessionQueryRequest, GetByIdConfessionQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdConfessionQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdConfessionQueryResponse> Handle(GetByIdConfessionQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdConfessionAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Languages = null,
                    Confession = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
