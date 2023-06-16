using MVCBlogApp.Application.ViewModels;
using System.Text;

namespace MVCBlogApp.Application.Features.Queries.Admin.Dashboard
{
    public class GetDashboardItemListQueryResponse
    {
        public int ActiveAllUserCount { get; set; }
        public List<VM_Member> ActiveOneMonthCreateUsers { get; set; }
        public int ActiveAllActivityCount { get; set; }
        public List<VM_Event> ActiveOneWeekActivities { get; set; }
        public int DailyIncomingMessageCount { get; set; }
        public int ActiveAllBlogCount { get; set; }
        public List<VM_Blog> ActiveOneWeekBlogs { get; set; }
        public List<VM_Confession> LastWeekConfession { get; set; }
        public int ActiveAllArticleCount { get; set; }
        public int LastWeekArticleCount { get; set; }
        public List<VM_D_Appointment> ActiveAllAppointment { get; set; }
        public List<VM_D_Appointment> ActiveLastWeekAppointment { get; set; }
    }
}