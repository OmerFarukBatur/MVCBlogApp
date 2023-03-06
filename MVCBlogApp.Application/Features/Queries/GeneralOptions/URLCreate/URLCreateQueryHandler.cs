using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.URLCreate
{
    public class URLCreateQueryHandler : IRequestHandler<URLCreateQueryRequest, URLCreateQueryResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public URLCreateQueryHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<URLCreateQueryResponse> Handle(URLCreateQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Title != null || (request.Title != "" && request.Title.Length > 1 && request.Title.Length < 251))
            {
                return new() 
                {
                    State= true,
                    Url = _generalOptionsService.URLCreate(request.Title)
            };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Lütfen değeri enaz 2 ve ençok 250 karakter olacak şekilde giriniz."
                };
            }
        }
    }
}
