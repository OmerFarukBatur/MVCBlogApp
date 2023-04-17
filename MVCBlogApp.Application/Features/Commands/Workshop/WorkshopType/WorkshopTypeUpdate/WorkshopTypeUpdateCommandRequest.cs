using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate
{
    public class WorkshopTypeUpdateCommandRequest : IRequest<WorkshopTypeUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string WstypeName { get; set; }
        public int LangId { get; set; }
    }
}