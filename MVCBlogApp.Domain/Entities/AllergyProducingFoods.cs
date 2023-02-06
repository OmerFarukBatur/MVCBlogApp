using MVCBlogApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
{
    public class AllergyProducingFoods : BaseEntity
    {
        public int MembersInformationID { get; set; }
        public string Like { get; set; }
        public string Dislike { get; set; }
        public string Allergen { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
    }
}
