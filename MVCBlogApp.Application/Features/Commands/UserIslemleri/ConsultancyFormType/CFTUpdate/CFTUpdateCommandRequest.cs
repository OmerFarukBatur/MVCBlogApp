using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTUpdate
{
    public class CFTUpdateCommandRequest : IRequest<CFTUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string ConsultancyFormTypeName { get; set; }
    }
}