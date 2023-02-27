using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class NewsPaper : BaseEntity
    {
        public string? NewsPaperName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
    }
}
