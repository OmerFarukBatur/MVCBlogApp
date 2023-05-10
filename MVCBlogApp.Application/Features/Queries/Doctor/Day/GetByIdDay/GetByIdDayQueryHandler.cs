using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay
{
    public class GetByIdDayQueryHandler : IRequestHandler<GetByIdDayQueryRequest, GetByIdDayQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _generalOptionsService;

        public GetByIdDayQueryHandler(IDoctorGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetByIdDayQueryResponse> Handle(GetByIdDayQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.GetByIdDayAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Day = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
