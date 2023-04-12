using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetAllCFT
{
    public class GetAllCFTQueryHandler : IRequestHandler<GetAllCFTQueryRequest, GetAllCFTQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetAllCFTQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetAllCFTQueryResponse> Handle(GetAllCFTQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetAllCFTAsync();
        }
    }
}
