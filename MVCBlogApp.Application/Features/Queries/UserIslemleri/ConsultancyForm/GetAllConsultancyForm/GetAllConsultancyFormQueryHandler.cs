using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyForm.GetAllConsultancyForm
{
    public class GetAllConsultancyFormQueryHandler : IRequestHandler<GetAllConsultancyFormQueryRequest, GetAllConsultancyFormQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetAllConsultancyFormQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetAllConsultancyFormQueryResponse> Handle(GetAllConsultancyFormQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userIslemleriService.GetAllConsultancyFormAsync();
        }
    }
}
