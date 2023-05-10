using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete
{
    public class DayDeleteCommandRequest : IRequest<DayDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}