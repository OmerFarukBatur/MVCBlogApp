using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class _DaysMeal : BaseEntity
    {
        public int DietListID { get; set; }
        public int DaysID { get; set; }
        public int MealID { get; set; }
        public TimeSpan TimeInterval { get; set; }
        public string Description { get; set; }

        public virtual Days Days { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual DietList DietList { get; set; }
    }
}
