using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.GetCalenderEventList
{
    public class GetCalenderEventListQueryResponse
    {
        public List<VM_CalenderData> D_Appointments { get; set; }
    }
}