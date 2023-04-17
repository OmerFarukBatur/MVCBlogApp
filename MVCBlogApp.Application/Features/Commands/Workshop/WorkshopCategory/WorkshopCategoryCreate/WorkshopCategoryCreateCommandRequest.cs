using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate
{
    public class WorkshopCategoryCreateCommandRequest : IRequest<WorkshopCategoryCreateCommandResponse>
    {
        public string WscategoryName { get; set; }
        public int LangId { get; set; }
    }
}