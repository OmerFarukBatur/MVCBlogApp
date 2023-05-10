using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate
{
    public class DayUpdateCommandRequest : IRequest<DayUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string DayName { get; set; }
    }
}