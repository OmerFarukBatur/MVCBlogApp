namespace MVCBlogApp.Application.ViewModels
{
    public class VM_D_Appointment
    {
        public int? Id { get; set; }
        public int? MembersId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public int? Interval { get; set; }
        public int? StatusId { get; set; }
        public bool? IsCompleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }

        public string? MemeberName { get; set; }
        public string? UserName { get; set; }
        public string? StatusName { get; set; }
    }
}
