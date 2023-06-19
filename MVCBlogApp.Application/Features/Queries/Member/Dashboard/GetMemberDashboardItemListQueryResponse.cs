using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Member.Dashboard
{
    public class GetMemberDashboardItemListQueryResponse
    {
        public int ActiveAllAppointmentCount { get; set; }
        public int ActiveAllActivityCount { get; set; }
        public List<VM_Event> ActiveOneWeekActivities { get; set; }
        public List<VM_D_Appointment> ActiveLastWeekAppointment { get; set; }
    }
}