using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class WorkshopType : BaseEntity
    {
        public string WSTypeName { get; set; }

        public virtual IList<Workshop> WorkShop { get; set; }

        //****Örnekler******//
            //Online
            //Yüzyüze

    }
}
