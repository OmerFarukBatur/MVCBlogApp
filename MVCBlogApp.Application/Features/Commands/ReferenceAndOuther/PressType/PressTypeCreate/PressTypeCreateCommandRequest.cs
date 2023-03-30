using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate
{
    public class PressTypeCreateCommandRequest : IRequest<PressTypeCreateCommandResponse>
    {
        public string PressTypeName { get; set; }
    }
}