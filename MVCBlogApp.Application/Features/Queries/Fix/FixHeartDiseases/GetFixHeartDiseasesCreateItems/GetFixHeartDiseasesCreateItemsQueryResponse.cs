using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetFixHeartDiseasesCreateItems
{
    public class GetFixHeartDiseasesCreateItemsQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Statuses { get; set; }
        public List<VM_Form> Forms { get; set; }
    }
}