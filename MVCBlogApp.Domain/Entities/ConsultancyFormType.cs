using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class ConsultancyFormType : BaseEntity
    {
        public string? ConsultancyFormTypeName { get; set; }

        public virtual IList<ConsultancyForm> ConsultancyForm { get; set; }
    }
}
