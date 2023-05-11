using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetDietListCreateItems
{
    public class GetDietListCreateItemsQueryHandler : IRequestHandler<GetDietListCreateItemsQueryRequest, GetDietListCreateItemsQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetDietListCreateItemsQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetDietListCreateItemsQueryResponse> Handle(GetDietListCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetDietListCreateItemsAsync();
        }
    }
}
