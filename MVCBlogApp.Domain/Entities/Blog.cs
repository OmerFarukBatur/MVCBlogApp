using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Contents { get; set; }
        public string Controller { get; set; } // Hangi kontroller a ait
        public string Action { get; set; } // Hangi sayfanın hangi action a ait
        public string CoverImgUrl { get; set; } // Listeleme Yapılırken default fotograf
        public bool IsMainPage { get; set; } // Ana Sayfada Gösterilecek mi

        
        public string UserId { get; set; }    
        public string BlogTypeID { get; set; }

        public virtual ICollection<BlogCategoryRelationship> Categories { get; set; }

    }
}
