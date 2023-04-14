using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdAppointmentDetail
{
    public class GetByIdAppointmentDetailQueryHandler : IRequestHandler<GetByIdAppointmentDetailQueryRequest, GetByIdAppointmentDetailQueryResponse>
    {
        private readonly IUserIslemleriService  _userIslemleriService;

        public GetByIdAppointmentDetailQueryHandler(IUserIslemleriService userIslemleriService)
        {
            _userIslemleriService = userIslemleriService;
        }

        public async Task<GetByIdAppointmentDetailQueryResponse> Handle(GetByIdAppointmentDetailQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _userIslemleriService.GetByIdAppointmentDetailAsync(request.Id);
            }
            else
            {
                return new()
                {
                    AppointmentDetail = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
