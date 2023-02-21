using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Status.UpdateStatus
{
    public class UpdateStatusCommandRequest : IRequest<UpdateStatusCommandResponse>
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}