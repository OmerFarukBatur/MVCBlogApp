using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public partial class D_Appointment : BaseEntity
    {
        public int? MembersId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public byte[]? Subject { get; set; }
        public string Description { get; set; } = null!;
        public int? Interval { get; set; }
        public int? StatusId { get; set; }
        public bool? IsCompleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
    }
}
