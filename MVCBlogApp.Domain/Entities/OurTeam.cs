using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class OurTeam : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }
        public virtual Status Status { get; set; }
    }
}
