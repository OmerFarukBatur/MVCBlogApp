using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Meal : BaseEntity
    {
       public string MealName { get; set; }

        public virtual IList<_DaysMeal> _DaysMeal { get; set; }
    }
}
