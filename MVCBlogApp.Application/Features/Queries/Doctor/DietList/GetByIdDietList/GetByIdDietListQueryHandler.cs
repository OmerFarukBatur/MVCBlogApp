using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList
{
    public class GetByIdDietListQueryHandler : IRequestHandler<GetByIdDietListQueryRequest, GetByIdDietListQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetByIdDietListQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetByIdDietListQueryResponse> Handle(GetByIdDietListQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _optionsService.GetByIdDietListAsync(request.Id);
            }
            else
            {
                return new()
                {
                    AppointmentDetails = null,
                    Days = null,
                    Meals = null,
                    DaysMeal = null,
                    DietList = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
