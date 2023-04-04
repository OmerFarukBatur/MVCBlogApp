using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch
{
    public class GetByIdFixCalorieSchQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_FixCalorieSch? FixCalorieSch { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Form>? Forms { get; set; }
    }
}