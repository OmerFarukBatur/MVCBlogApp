using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class HearAboutUS : BaseEntity
    {
        public string HearAboutUSName { get; set; }
        public int LangID { get; set; }

        public virtual IList<WorkShopApplicationForm> WorkShopApplicationForm { get; set; }
    }    
}
