using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate
{
    public class EventCreateCommandRequest : IRequest<EventCreateCommandResponse>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime FinishTime { get; set; }
        public int EventCategoryId { get; set; }
        public int? CreateUserId { get; set; }
        public int StatusId { get; set; }
    }
}