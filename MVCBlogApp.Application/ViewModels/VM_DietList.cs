namespace MVCBlogApp.Application.ViewModels
{
    public class VM_DietList
    {
        public int? Id { get; set; }
        public int? AppointmentDetailId { get; set; }
        public int? UserId { get; set; } // Create UserId
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
