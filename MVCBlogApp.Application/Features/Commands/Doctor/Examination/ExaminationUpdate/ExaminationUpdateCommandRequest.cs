using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationUpdate
{
    public class ExaminationUpdateCommandRequest : IRequest<ExaminationUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string ExaminatioName { get; set; }
    }
}