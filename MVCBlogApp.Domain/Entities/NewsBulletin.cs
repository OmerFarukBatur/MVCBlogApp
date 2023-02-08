using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class NewsBulletin : BaseEntity
    {
        public string Email { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
    }
}
