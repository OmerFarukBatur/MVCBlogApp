using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetAllLab
{
    public class GetAllLabQueryResponse
    {
        public List<VM_Lab> Labs { get; set; }
    }
}