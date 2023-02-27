using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class AllergyProducingFoods : BaseEntity
    {
        public int? MembersInformationId { get; set; }
        public string? Like { get; set; }
        public string? Dislike { get; set; }
        public string? Allergen { get; set; }

        public virtual MembersInformation? MembersInformation { get; set; }
    }
}
