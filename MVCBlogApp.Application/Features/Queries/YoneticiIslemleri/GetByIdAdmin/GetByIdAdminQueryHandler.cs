using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin
{
    public class GetByIdAdminQueryHandler : IRequestHandler<GetByIdAdminQueryRequest, GetByIdAdminQueryResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public GetByIdAdminQueryHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<GetByIdAdminQueryResponse> Handle(GetByIdAdminQueryRequest request, CancellationToken cancellationToken)
        {
            if(request != null)
            {
                return await _yoneticiIslemleri.GetByIdAdminAsync(request.Id);                
            }
            else
            {
                return new GetByIdAdminQueryResponse() 
                {
                    Message = "Böyle bir kayıt bulunmamaktadır."
                };
            }
        }
    }
}
