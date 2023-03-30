using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeUpdate
{
    public class PressTypeUpdateCommandRequest : IRequest<PressTypeUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string PressTypeName { get; set; }
    }
}