using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAllAppointmentDetail
{
    public class GetAllAppointmentDetailQueryResponse
    {
        public List<VM_AppointmentDetail> AppointmentDetails { get; set; }
    }
}