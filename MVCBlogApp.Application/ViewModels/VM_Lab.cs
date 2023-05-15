namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Lab
    {
        public int? Id { get; set; }
        public int? AppointmentDetailId { get; set; }
        public int? MembersId { get; set; }
        public int? UsersId { get; set; }
        public DateTime? LabDateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? MemberName { get; set; }
        public string? UserName { get; set; }
        public string? Diagnosis { get; set; }
    }
}
