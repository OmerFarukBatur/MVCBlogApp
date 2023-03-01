using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate
{
    public class BookCategoryCreateCommandRequest : IRequest<BookCategoryCreateCommandResponse>
    {
        public string CategoryName { get; set; }
        public int StatusId { get; set; }
        public int LangId { get; set; }
        public int? CreateUser { get; set; }
    }
}