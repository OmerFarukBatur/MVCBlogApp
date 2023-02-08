using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class MembersDetail : BaseEntity
    {
        public int MembersID { get; set; }

        public int size { get; set; }
        public decimal Weight { get; set; }
        public decimal FatRate { get; set; }

        public DateTime BirtDate { get; set; }

        public virtual Members Members { get; set; }
    }
}
