using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class DiseasesDiabetes : BaseEntity
    {
        public int MembersInformationID { get; set; }
        public int DiseasesID { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
        public virtual Diseases Diseases { get; set; }
    }
}
