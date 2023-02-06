using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class _Examination : BaseEntity
    {
        public int ExaminationID { get; set; }
        public int LabID { get; set; }

        public string Value { get; set; }

        public virtual Examination Examination { get; set; }
        public virtual Lab Lab { get; set; }
    }
}
