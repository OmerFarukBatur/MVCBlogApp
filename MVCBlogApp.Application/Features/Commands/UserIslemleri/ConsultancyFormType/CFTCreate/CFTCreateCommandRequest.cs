using MediatR;

namespace MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTCreate
{
    public class CFTCreateCommandRequest : IRequest<CFTCreateCommandResponse>
    {
        public string ConsultancyFormTypeName { get; set; }
    }
}