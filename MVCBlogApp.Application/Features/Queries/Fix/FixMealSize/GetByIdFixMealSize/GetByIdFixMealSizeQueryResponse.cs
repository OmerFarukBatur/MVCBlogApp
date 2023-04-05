using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize
{
    public class GetByIdFixMealSizeQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_FixMealSize? FixMealSize { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_Form>? Forms { get; set; }
    }
}