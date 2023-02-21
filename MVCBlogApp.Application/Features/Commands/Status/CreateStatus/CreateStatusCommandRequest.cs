using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Status.CreateStatus
{
    public class CreateStatusCommandRequest : IRequest<CreateStatusCommandResponse>
    {
        public string StatusName { get; set; }
    }
}