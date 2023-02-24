using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Genders : BaseEntity
    {
        public string? Gender { get; set; }
        public int? LangID { get; set; }
    }
}
