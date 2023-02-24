using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ResultBMI : BaseEntity
    {
        public decimal? IntervalMin { get; set; }
        public decimal? IntervalMax { get; set; }
        public string? IntervalDescription { get; set; }
    }
}
