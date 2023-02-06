using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ContactCategory : BaseEntity
    {
        public string ContactCategoryName { get; set; }
        public int LangID { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
    }
}
