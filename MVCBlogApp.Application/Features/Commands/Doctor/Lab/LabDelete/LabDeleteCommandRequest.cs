using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabDelete
{
    public class LabDeleteCommandRequest : IRequest<LabDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}