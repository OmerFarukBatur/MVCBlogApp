using MVCBlogApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlogApp.Domain.Entities
{
    public class Workshop : BaseEntity
    {
        public string Title { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FinishDateTime { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int WSEducationID { get; set; }
        public int WSTypeID { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public int StatusID { get; set; }

        public int LangID { get; set; }

        public virtual WorkshopEducation WorkshopEducation { get; set; }
        public virtual WorkshopType WorkshopType { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual IList<WorkShopApplicationForm> WorkShopApplicationForm { get; set; }
    }
}
