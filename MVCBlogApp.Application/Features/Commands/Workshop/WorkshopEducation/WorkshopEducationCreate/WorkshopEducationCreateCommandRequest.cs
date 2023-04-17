using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate
{
    public class WorkshopEducationCreateCommandRequest : IRequest<WorkshopEducationCreateCommandResponse>
    {
        public int WscategoryId { get; set; }
        public string WsEducationName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}