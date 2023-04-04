using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetFixCalorieSchCreateItems
{
    public class GetFixCalorieSchCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_Form> Forms { get; set; }
    }
}