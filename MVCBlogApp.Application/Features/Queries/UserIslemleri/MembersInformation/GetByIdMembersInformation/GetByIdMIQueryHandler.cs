using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MembersInformation.GetByIdMembersInformation
{
    public class GetByIdMIQueryHandler : IRequestHandler<GetByIdMIQueryRequest, GetByIdMIQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdMIQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdMIQueryResponse> Handle(GetByIdMIQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdMIAsync(request.Id);
            }
            else
            {
                return new()
                {
                    MemberAllDetail = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
