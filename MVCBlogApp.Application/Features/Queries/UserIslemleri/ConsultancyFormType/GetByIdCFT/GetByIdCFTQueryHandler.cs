using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetByIdCFT
{
    public class GetByIdCFTQueryHandler : IRequestHandler<GetByIdCFTQueryRequest, GetByIdCFTQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdCFTQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdCFTQueryResponse> Handle(GetByIdCFTQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdCFTAsync(request.Id);
            }
            else
            {
                return new()
                {
                    ConsultancyFormType = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
