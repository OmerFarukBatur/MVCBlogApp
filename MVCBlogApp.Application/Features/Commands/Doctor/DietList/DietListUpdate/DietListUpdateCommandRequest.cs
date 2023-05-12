using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate
{
    public class DietListUpdateCommandRequest : IRequest<DietListUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int AppointmentDetailId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int DaysId { get; set; }
        public TimeSpan TimeInterval { get; set; }
        public int MealId { get; set; }
        public string? _DaysDescription { get; set; }
    }
}