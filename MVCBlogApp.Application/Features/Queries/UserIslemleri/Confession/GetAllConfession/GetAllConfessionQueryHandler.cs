using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession
{
    public class GetAllConfessionQueryHandler : IRequestHandler<GetAllConfessionQueryRequest, GetAllConfessionQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetAllConfessionQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetAllConfessionQueryResponse> Handle(GetAllConfessionQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetAllConfessionAsync();
        }
    }
}
