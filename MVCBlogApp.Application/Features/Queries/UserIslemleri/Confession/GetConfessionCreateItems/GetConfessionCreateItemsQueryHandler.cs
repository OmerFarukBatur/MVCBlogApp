using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetConfessionCreateItems
{
    public class GetConfessionCreateItemsQueryHandler : IRequestHandler<GetConfessionCreateItemsQueryRequest, GetConfessionCreateItemsQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetConfessionCreateItemsQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetConfessionCreateItemsQueryResponse> Handle(GetConfessionCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetConfessionCreateItemsAsync();
        }
    }
}
