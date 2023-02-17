using MediatR;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove
{
    public class AdminByIdRemoveCommandRequest : IRequest<AdminByIdRemoveCommandResponse>
    {
        public int Id { get; set; }
    }
}