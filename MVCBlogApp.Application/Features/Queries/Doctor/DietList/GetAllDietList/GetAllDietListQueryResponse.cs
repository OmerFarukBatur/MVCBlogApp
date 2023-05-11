using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetAllDietList
{
    public class GetAllDietListQueryResponse
    {
        public List<VM_AllDietList> AllDietLists { get; set; }
    }
}