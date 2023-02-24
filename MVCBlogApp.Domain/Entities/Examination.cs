using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Examination : BaseEntity
    {
        public string? ExaminationName { get; set; }

        public virtual IList<_Examination> _Examination { get; set; }
    }
}
