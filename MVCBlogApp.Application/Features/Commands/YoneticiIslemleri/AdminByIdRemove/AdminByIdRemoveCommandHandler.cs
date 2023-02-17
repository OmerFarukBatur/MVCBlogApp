using MediatR;
using MVCBlogApp.Application.Repositories.User;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove
{
    public class AdminByIdRemoveCommandHandler : IRequestHandler<AdminByIdRemoveCommandRequest, AdminByIdRemoveCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public AdminByIdRemoveCommandHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        public async Task<AdminByIdRemoveCommandResponse> Handle(AdminByIdRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                await _userWriteRepository.Remove(request.Id);
                await _userWriteRepository.SaveAsync();
                return new() 
                { 
                    Message = "Kayıt başarıyla silinmiştir." 
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sırasında beklenmedik bir hata oluştu."
                };
            }
        }
    }
}
