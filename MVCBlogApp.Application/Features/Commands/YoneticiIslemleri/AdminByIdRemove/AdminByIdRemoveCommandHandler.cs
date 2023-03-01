using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove
{
    public class AdminByIdRemoveCommandHandler : IRequestHandler<AdminByIdRemoveCommandRequest, AdminByIdRemoveCommandResponse>
    {
        private readonly IYoneticiIslemleri _yoneticiIslemleri;

        public AdminByIdRemoveCommandHandler(IYoneticiIslemleri yoneticiIslemleri)
        {
            _yoneticiIslemleri = yoneticiIslemleri;
        }

        public async Task<AdminByIdRemoveCommandResponse> Handle(AdminByIdRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _yoneticiIslemleri.AdminDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }
    }
}
