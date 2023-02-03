using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Diseases
    {
        [Key]
        public int ID { get; set; }
        public string DiseasesName { get; set; }
        public int Type { get; set; }

        public virtual IList<DiseasesCardiovascular> DiseasesCardiovasculars { get; set; }
        public virtual IList<DiseasesDiabetes> DiseasesDiabetes { get; set; }
        public virtual IList<DiseasesDigestiveDisorders> DiseasesDigestiveDisorders { get; set; }
        public virtual IList<DiseasesFamilyMembers> DiseasesFamilyMembers { get; set; }
    }
}
