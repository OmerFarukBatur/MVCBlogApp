using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Diseases : BaseEntity
    {
        public string DiseasesName { get; set; }
        public int Type { get; set; }

        public virtual IList<DiseasesCardiovascular> DiseasesCardiovasculars { get; set; }
        public virtual IList<DiseasesDiabetes> DiseasesDiabetes { get; set; }
        public virtual IList<DiseasesDigestiveDisorders> DiseasesDigestiveDisorders { get; set; }
        public virtual IList<DiseasesFamilyMembers> DiseasesFamilyMembers { get; set; }
    }
}
