using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdLab
{
    public class GetByIdLabQueryHandler : IRequestHandler<GetByIdLabQueryRequest, GetByIdLabQueryResponse>
    {
        private readonly IUserIslemleriService _userIslemleriService;

        public GetByIdLabQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdLabQueryResponse> Handle(GetByIdLabQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdLabAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Examinations = null,
                    Lab = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
