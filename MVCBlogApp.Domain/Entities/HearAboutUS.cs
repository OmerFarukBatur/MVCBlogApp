using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class HearAboutUS : BaseEntity
    {
        public string? HearAboutUsname { get; set; }
        public int? LangId { get; set; }
    }
}
