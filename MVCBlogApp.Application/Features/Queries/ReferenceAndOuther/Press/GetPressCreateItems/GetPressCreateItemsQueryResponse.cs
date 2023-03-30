using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetPressCreateItems
{
    public class GetPressCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_NewsPaper> NewsPapers { get; set; }
        public List<VM_PressType> PressTypes { get; set; }
    }
}