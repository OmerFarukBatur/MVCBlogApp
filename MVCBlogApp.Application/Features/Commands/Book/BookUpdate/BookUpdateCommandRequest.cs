using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Book.BookUpdate
{
    public class BookUpdateCommandRequest : IRequest<BookUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int PublicationYear { get; set; }
        public string Content { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int StatusId { get; set; }
        public int NavigationId { get; set; }
        public int LangId { get; set; }
        public List<int> BookCategoryId { get; set; }
    }
}