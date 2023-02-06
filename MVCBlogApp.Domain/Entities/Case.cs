using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Case : BaseEntity
    {
        public string CaseName { get; set; }
        public int LangID { get; set; }
    }
}
