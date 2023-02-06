using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ResultPulse : BaseEntity
    {
        public string ResultMaxText { get; set; }
        public string ResultMinText { get; set; }
    }
}
