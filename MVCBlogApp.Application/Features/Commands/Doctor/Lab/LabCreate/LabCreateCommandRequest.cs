using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Lab.LabCreate
{
    public class LabCreateCommandRequest : IRequest<LabCreateCommandResponse>
    {
        public string AppointmentDetailId { get; set; }
        public int UsersId { get; set; }
        public DateTime LabDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> ExaminationId { get; set; }
    }
}