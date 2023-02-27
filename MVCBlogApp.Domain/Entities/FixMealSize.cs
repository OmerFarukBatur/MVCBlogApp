using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FixMealSize : BaseEntity
    {
        public int? FormId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public virtual Form? Form { get; set; }
    }
}
