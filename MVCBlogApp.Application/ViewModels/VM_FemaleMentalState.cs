namespace MVCBlogApp.Application.ViewModels
{
    public class VM_FemaleMentalState
    {
        public int? Id { get; set; }
        public int? MembersInformationId { get; set; }
        public string? Menstruation { get; set; }
        public string? Menopause { get; set; }
        public string? Gravidity { get; set; }
        public string? BreastFeeding { get; set; }
        public string? IsBreastFeedingPeriod { get; set; }
        public string? IsMenstruatioRegular { get; set; }
        public string? IsHormontherapy { get; set; }
        public string? IsGiveBirthTo { get; set; }
    }
}
