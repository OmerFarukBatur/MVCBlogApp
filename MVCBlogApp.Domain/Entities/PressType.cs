using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class PressType : BaseEntity
    {
        public string PressTypeName { get; set; }

        public virtual IList<Press> Press { get; set; }
    }
}
