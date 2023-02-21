using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Status.DeleteStatus
{
    public class DeleteStatusCommandRequest : IRequest<DeleteStatusCommandResponse>
    {
        public int Id { get; set; }
    }
}