using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string BannerName { get; set; }
        public string BannerUrl { get; set; }

        public int Type { get; set; }
        public int BannerOrder { get; set; }
        public int StatusID { get; set; }
        public string DateString { get; set; }

        public int LangID { get; set; }

        public virtual Languages Languages { get; set; }
    }
}
