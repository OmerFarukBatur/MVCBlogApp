using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string StatusName { get; set; }

        public virtual IList<TaylanK> TaylanK { get; set; }
        

    }
}
