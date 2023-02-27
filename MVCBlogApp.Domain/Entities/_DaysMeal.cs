using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class _DaysMeal : BaseEntity
    {
        public int? DietListId { get; set; }
        public int? DaysId { get; set; }
        public TimeSpan? TimeInterval { get; set; }
        public int? MealId { get; set; }
        public string? Description { get; set; }
    }
}
