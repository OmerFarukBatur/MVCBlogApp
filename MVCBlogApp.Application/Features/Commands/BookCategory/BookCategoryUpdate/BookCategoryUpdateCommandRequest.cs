using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate
{
    public class BookCategoryUpdateCommandRequest : IRequest<BookCategoryUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
    }
}