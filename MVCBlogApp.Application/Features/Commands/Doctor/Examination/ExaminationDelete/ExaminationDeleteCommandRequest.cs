using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationDelete
{
    public class ExaminationDeleteCommandRequest : IRequest<ExaminationDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}