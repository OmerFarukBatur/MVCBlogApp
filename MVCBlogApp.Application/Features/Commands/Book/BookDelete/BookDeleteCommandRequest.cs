using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Book.BookDelete
{
    public class BookDeleteCommandRequest : IRequest<BookDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}