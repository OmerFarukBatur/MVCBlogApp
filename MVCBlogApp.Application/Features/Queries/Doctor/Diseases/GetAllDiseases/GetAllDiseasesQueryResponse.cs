using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetAllDiseases
{
    public class GetAllDiseasesQueryResponse
    {
        public List<VM_Diseases> Diseases { get; set; }
    }
}