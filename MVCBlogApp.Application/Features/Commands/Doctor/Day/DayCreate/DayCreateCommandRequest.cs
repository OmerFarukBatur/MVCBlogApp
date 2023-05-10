using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate
{
    public class DayCreateCommandRequest : IRequest<DayCreateCommandResponse>
    {
        public string DayName { get; set; }
    }
}