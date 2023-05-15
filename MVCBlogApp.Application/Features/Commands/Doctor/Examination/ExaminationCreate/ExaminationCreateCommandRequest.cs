using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationCreate
{
    public class ExaminationCreateCommandRequest : IRequest<ExaminationCreateCommandResponse>
    {
        public string ExaminatioName { get; set; }
    }
}