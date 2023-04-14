using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate
{
    public class WorkshopTypeCreateCommandRequest : IRequest<WorkshopTypeCreateCommandResponse>
    {
        public string WstypeName { get; set; }
        public int LangId { get; set; }
    }
}