using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate
{
    public class BlogCategoryCreateCommandRequest : IRequest<BlogCategoryCreateCommandResponse>
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}