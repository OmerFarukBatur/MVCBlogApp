using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBook.GetAllActiveBooks
{
    public class GetAllActiveBlogQueryResponse
    {
        public List<VM_Book> Books { get; set; }
    }
}