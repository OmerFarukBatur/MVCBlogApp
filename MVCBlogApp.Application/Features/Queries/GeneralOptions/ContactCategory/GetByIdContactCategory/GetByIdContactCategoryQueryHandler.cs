using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.ContactCategory.GetByIdContactCategory
{
    public class GetByIdContactCategoryQueryHandler : IRequestHandler<GetByIdContactCategoryQueryRequest, GetByIdContactCategoryQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetByIdContactCategoryQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetByIdContactCategoryQueryResponse> Handle(GetByIdContactCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.GetByIdContactCategoryAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    ContactCategory = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }
    }
}
