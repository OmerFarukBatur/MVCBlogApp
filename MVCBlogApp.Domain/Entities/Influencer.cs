using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Influencer : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string Message { get; set; }
        public int StatusID { get; set; }
    }
}
