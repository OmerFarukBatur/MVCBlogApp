using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FoodTime : BaseEntity
    {
        public int? MembersInformationId { get; set; }
        public string? WeekdayMorning { get; set; }
        public string? WeekdayNoon { get; set; }
        public string? WeekdayNight { get; set; }
        public string? WeekendMorning { get; set; }
        public string? WeekendNoon { get; set; }
        public string? WeekendNight { get; set; }

        public virtual MembersInformation? MembersInformation { get; set; }
    }
}
