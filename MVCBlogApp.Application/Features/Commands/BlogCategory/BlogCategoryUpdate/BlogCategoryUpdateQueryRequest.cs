using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate
{
    public class BlogCategoryUpdateQueryRequest : IRequest<BlogCategoryUpdateQueryResponse>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}