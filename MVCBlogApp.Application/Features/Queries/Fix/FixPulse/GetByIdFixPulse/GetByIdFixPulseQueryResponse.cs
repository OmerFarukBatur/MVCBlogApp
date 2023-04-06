using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetByIdFixPulse
{
    public class GetByIdFixPulseQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_FixPulse? FixPulse { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Form>? Forms { get; set; }
    }
}