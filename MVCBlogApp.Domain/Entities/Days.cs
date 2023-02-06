using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Days : BaseEntity
    {
        public string DayName { get; set; }

        public virtual IList<_DaysMeal> _DaysMeal { get; set; }

    }
}
