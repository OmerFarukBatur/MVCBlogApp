using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetAllLab
{
    public class GetAllLabQueryHandler : IRequestHandler<GetAllLabQueryRequest, GetAllLabQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetAllLabQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetAllLabQueryResponse> Handle(GetAllLabQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetAllLabAsync();
        }
    }
}
