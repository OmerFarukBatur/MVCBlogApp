using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool? IsRead { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual Status Status { get; set; }
        public int? ContactCategoryID { get; set; }

        public virtual ContactCategory ContactCategory { get; set; }
    }
}
