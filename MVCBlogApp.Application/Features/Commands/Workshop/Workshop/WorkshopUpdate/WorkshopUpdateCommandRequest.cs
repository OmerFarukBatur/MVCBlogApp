using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopUpdate
{
    public class WorkshopUpdateCommandRequest : IRequest<WorkshopUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime FinishTime { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int WseducationId { get; set; }
        public int WstypeId { get; set; }
        public int LangId { get; set; }
        public int StatusId { get; set; }
        public int NavigationId { get; set; }
    }
}