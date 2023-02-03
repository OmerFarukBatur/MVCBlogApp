using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class AllergyProducingFoods
    {
        [Key]
        public int ID { get; set; }
        public int MembersInformationID { get; set; }
        public string Like { get; set; }
        public string Dislike { get; set; }
        public string Allergen { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
    }
}
