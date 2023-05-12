using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetAllDietList
{
    public class GetAllDietListQueryHandler : IRequestHandler<GetAllDietListQueryRequest, GetAllDietListQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetAllDietListQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetAllDietListQueryResponse> Handle(GetAllDietListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetAllDietListAsync();
        }
    }
}
