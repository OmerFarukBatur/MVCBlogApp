using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Dashboard
{
    public class GetDoctorDashboardItemListQueryResponse
    {
        public int ActiveAllUserCount { get; set; }
        public int ActiveAllActivityCount { get; set; }
        public List<VM_Event> ActiveOneWeekActivities { get; set; }
        public List<VM_D_Appointment> ActiveLastWeekAppointment { get; set; }
    }
}