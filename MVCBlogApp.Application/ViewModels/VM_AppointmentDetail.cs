namespace MVCBlogApp.Application.ViewModels
{
    public class VM_AppointmentDetail
    {
        public int? Id { get; set; }
        public int? AppointmentId { get; set; }
        public int? MembersId { get; set; }
        public int? UserId { get; set; }
        public string? Diagnosis { get; set; }
        public string? History { get; set; }
        public string? Treatment { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Size { get; set; }
        public decimal? OilRate { get; set; }

        public string? MemberName { get; set; }
        public string? UserName { get; set; }
    }
}
