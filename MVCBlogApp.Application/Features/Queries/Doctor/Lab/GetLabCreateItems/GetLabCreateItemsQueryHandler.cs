using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetLabCreateItems
{
    public class GetLabCreateItemsQueryHandler : IRequestHandler<GetLabCreateItemsQueryRequest, GetLabCreateItemsQueryResponse>
    {
        private readonly IDoctorGeneralOptionsService _optionsService;

        public GetLabCreateItemsQueryHandler(IDoctorGeneralOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public async Task<GetLabCreateItemsQueryResponse> Handle(GetLabCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _optionsService.GetLabCreateItemsAsync();
        }
    }
}
