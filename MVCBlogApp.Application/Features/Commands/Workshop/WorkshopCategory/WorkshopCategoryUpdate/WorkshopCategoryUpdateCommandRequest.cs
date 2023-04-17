using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate
{
    public class WorkshopCategoryUpdateCommandRequest : IRequest<WorkshopCategoryUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string WscategoryName { get; set; }
        public int LangId { get; set; }
    }
}