using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems
{
    public class GetUserCreateItemsQueryHandler : IRequestHandler<GetUserCreateItemsQueryRequest, GetUserCreateItemsQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetUserCreateItemsQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetUserCreateItemsQueryResponse> Handle(GetUserCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetUserCreateItemsAsync();
        }
    }
}
