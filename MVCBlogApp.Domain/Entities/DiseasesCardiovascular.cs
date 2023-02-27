using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class DiseasesCardiovascular : BaseEntity
    {
        public int? MembersInformationId { get; set; }
        public int? DiseasesId { get; set; }

        public virtual Diseases? Diseases { get; set; }
        public virtual MembersInformation? MembersInformation { get; set; }
    }
}
