using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopEducation : BaseEntity
    {
        public int? WscategoryId { get; set; }
        public string? WsEducationName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
    }
}
