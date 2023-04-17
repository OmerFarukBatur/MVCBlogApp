using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete
{
    public class WorkshopCategoryDeleteCommandRequest : IRequest<WorkshopCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}