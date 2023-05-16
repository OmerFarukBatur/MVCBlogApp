using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Lab.GetByIdLab
{
    public class GetByIdLabQueryResponse
    {
        public List<VM_Admin>? Admins { get; set; }
        public List<VM_Examination>? Examinations { get; set; }
        public List<VM_AppointmentDetail>? AppointmentDetails { get; set; }
        public VM_Lab? Lab { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}