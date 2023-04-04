using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI
{
    public class GetByIdFixBMIQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_FixBMI? FixBMI { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Form>? Forms { get; set; }
    }
}