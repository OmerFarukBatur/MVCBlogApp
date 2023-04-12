using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTDelete
{
    public class CFTDeleteCommandRequest : IRequest<CFTDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}