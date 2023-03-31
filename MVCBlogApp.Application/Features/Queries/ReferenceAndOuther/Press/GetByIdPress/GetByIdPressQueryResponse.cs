using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetByIdPress
{
    public class GetByIdPressQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Press? Press { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_NewsPaper>? NewsPapers { get; set; }
        public List<VM_PressType>? PressTypes { get; set; }
    }
}