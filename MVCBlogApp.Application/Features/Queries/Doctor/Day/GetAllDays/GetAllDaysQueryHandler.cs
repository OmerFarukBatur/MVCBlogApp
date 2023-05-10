using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays
{
    public class GetAllDaysQueryHandler : IRequestHandler<GetAllDaysQueryRequest, GetAllDaysQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetAllDaysQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetAllDaysQueryResponse> Handle(GetAllDaysQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetAllDaysAsync();
        }
    }
}
