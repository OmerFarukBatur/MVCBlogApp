using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList
{
    public class GetCalenderEventListQueryResponse
    {
        public List<VM_CalenderData> D_Appointments { get; set; }
    }
}