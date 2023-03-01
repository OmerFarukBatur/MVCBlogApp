using MediatR;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete
{
    public class BookCategoryDeleteCommandRequest : IRequest<BookCategoryDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}