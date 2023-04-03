using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh
{
    public class GetByIdFixBmhQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_FixBmh? FixBmh { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Form>? Forms { get; set; }
    }
}