using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetByIdLab
{
    public class GetByIdLabQueryHandler : IRequestHandler<GetByIdLabQueryRequest, GetByIdLabQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetByIdLabQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetByIdLabQueryResponse> Handle(GetByIdLabQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.GetByIdLabAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Admins = null,
                    AppointmentDetails = null,
                    Examinations = null,
                    Lab = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
