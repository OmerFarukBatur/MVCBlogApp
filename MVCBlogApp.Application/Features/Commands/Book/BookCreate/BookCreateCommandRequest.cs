using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Book.BookCreate
{
    public class BookCreateCommandRequest : IRequest<BookCreateCommandResponse>
    {
        
        public string BookName { get; set; }
        public int PublicationYear { get; set; }
        public string Content { get; set; }
        public IFormFileCollection FormFile { get; set; }
        public int StatusId { get; set; }
        public int NavigationId { get; set; }
        public int LangId { get; set; }
        public int? CreatedUserId { get; set; }
        public List<int> BookCategoryId { get; set; }
    }
}