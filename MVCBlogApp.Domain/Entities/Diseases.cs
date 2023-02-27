using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Diseases : BaseEntity
    {
        public Diseases()
        {
            DiseasesCardiovasculars = new HashSet<DiseasesCardiovascular>();
            DiseasesDiabetes = new HashSet<DiseasesDiabetes>();
            DiseasesDigestiveDisorders = new HashSet<DiseasesDigestiveDisorders>();
            DiseasesFamilyMembers = new HashSet<DiseasesFamilyMembers>();
        }

        public string? DiseasesName { get; set; }
        public int? Type { get; set; }

        public virtual ICollection<DiseasesCardiovascular> DiseasesCardiovasculars { get; set; }
        public virtual ICollection<DiseasesDiabetes> DiseasesDiabetes { get; set; }
        public virtual ICollection<DiseasesDigestiveDisorders> DiseasesDigestiveDisorders { get; set; }
        public virtual ICollection<DiseasesFamilyMembers> DiseasesFamilyMembers { get; set; }
    }
}
