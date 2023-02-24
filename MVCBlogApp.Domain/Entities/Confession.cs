using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Confession : BaseEntity
    {
        public string? MemberConfession { get; set; }
        public string? MemberName { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsAprove { get; set; }
        public bool? IsRead { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreateDatetime { get; set; }

    }
}
