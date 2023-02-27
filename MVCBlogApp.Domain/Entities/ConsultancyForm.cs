using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ConsultancyForm : BaseEntity
    {
        public int? ConsultancyFormTypeId { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
