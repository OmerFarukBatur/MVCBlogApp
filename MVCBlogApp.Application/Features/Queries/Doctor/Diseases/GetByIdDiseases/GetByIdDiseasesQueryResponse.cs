using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetByIdDiseases
{
    public class GetByIdDiseasesQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Diseases? Diseases { get; set; }
    }
}