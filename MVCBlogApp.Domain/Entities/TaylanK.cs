using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class TaylanK : BaseEntity
    {
        public string? About { get; set; }
        public string? Bio { get; set; }
        public string? CompanyName { get; set; }
        public string? Adress { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Fax { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? GoogleMap { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Pinterest { get; set; }
        public string? Logo { get; set; }

        public int? StatusID { get; set; }

        public string? Metakey { get; set; }
        public string? Metatitle { get; set; }
        public string? Metadescription { get; set; }
        public string? CreateDate { get; set; }
        public int? UserID { get; set; }

        public int? LangID { get; set; }

        public virtual User User { get; set; }
        public virtual Languages Languages { get; set; }
        public virtual Status Status { get; set; }
    }
}
