using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FemaleMentalState : BaseEntity
    {
        public int? MembersInformationID { get; set; }
        public string? Menstruation { get; set; }
        public string? Menopause { get; set; }
        public string? Gravidity { get; set; }
        public string? BreastFeeding { get; set; }
        public string? IsBreastFeedingPeriod { get; set; }
        public string? IsMenstruatioRegular { get; set; }
        public string? IsHormontherapy { get; set; }
        public string? IsGiveBirthTo { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
    }
}
