using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.IUWorkShop.GetWorkshopEducation
{
    public class GetWorkshopEducationQueryHandler : IRequestHandler<GetWorkshopEducationQueryRequest, GetWorkshopEducationQueryResponse>
    {
        private readonly IUIOtherService _service;

        public GetWorkshopEducationQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<GetWorkshopEducationQueryResponse> Handle(GetWorkshopEducationQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.WsCategoryID > 0)
            {
                return await _service.GetWorkshopEducationAsync(request);
            }
            else
            {
                return new()
                {
                    WorkshopEducations = null
                };
            }
        }
    }
}
