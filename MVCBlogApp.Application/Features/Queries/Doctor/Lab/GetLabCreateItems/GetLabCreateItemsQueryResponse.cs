using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetLabCreateItems
{
    public class GetLabCreateItemsQueryResponse
    {
        public List<VM_Admin> Admins { get; set; }
        public List<VM_Examination> Examinations { get; set; }
        public List<VM_AppointmentDetail> AppointmentDetails { get; set; }
    }
}