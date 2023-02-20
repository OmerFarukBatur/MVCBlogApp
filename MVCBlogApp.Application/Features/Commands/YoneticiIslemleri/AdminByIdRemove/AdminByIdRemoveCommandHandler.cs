using MediatR;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove
{
    public class AdminByIdRemoveCommandHandler : IRequestHandler<AdminByIdRemoveCommandRequest, AdminByIdRemoveCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public AdminByIdRemoveCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<AdminByIdRemoveCommandResponse> Handle(AdminByIdRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                User user  = await _userReadRepository.GetByIdAsync(request.Id);
                user.IsActive = false;
                _userWriteRepository.Update(user);
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
