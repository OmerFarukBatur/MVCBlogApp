using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetAllForms
{
    public class GetAllFormsQueryHandler : IRequestHandler<GetAllFormsQueryRequest, GetAllFormsQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetAllFormsQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetAllFormsQueryResponse> Handle(GetAllFormsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _generalOptionsService.GetAllFormsAsync();
        }
    }
}
