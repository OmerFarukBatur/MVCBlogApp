using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class NewsPaper : BaseEntity
    {
        public string? NewsPaperName { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Press> Press { get; set; }
    }
}
