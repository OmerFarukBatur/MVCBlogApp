using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdUserQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdUserAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Member = null,
                    UserAuths = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
