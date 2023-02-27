using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class Lab : BaseEntity
    {
        public int? AppointmentDetailId { get; set; }
        public int? MembersId { get; set; }
        public int? UsersId { get; set; }
        public DateTime? LabDateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
