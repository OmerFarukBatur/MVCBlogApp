using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationDelete
{
    public class WorkshopEducationDeleteCommandRequest : IRequest<WorkshopEducationDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}