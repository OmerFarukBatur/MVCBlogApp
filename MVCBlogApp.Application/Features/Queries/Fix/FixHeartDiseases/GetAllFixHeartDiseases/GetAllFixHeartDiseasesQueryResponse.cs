using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetAllFixHeartDiseases
{
    public class GetAllFixHeartDiseasesQueryResponse
    {
        public List<VM_FixHeartDiseases> FixHeartDiseases { get; set; }
    }
}