using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberByIdAppointmentDetail
{
    public class GetByIdMemberByIdAppointmentDetailQueryHandler : IRequestHandler<GetByIdMemberByIdAppointmentDetailQueryRequest, GetByIdMemberByIdAppointmentDetailQueryResponse>
    {
        private readonly IMemberGeneralProcess _memberGeneralProcess;

        public GetByIdMemberByIdAppointmentDetailQueryHandler(IMemberGeneralProcess memberGeneralProcess)
        {
            _memberGeneralProcess = memberGeneralProcess;
        }

        public async Task<GetByIdMemberByIdAppointmentDetailQueryResponse> Handle(GetByIdMemberByIdAppointmentDetailQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _memberGeneralProcess.GetByIdMemberByIdAppointmentAsync(request.Id);
            }
            else
            {
                return new()
                {
                    D_Appointment = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
