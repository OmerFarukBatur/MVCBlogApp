using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetPage
{
    public class GetPageQueryResponse
    {
        public VM_Blog? Blog { get; set; }
        public VM_Article? Article { get; set; }
        public VM_Book? Book { get; set; }
        public VM_Press? Press { get; set; }
        public VM_MasterRoot? MasterRoot { get; set; }
    }
}