using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationUpdate
{
    public class WorkshopEducationUpdateCommandRequest : IRequest<WorkshopEducationUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int WscategoryId { get; set; }
        public string WsEducationName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}