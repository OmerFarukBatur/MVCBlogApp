using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm
{
    public class GetByIdFormQueryHandler : IRequestHandler<GetByIdFormQueryRequest, GetByIdFormQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public GetByIdFormQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<GetByIdFormQueryResponse> Handle(GetByIdFormQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _generalOptionsService.GetByIdFormAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Form = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
