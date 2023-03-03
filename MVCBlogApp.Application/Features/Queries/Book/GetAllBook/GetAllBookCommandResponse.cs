using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookCommandResponse
    {
        public List<VM_Book> Books { get; set; }
    }
}