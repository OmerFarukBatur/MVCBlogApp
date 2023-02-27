using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class _Examination : BaseEntity
    {
        public int? ExaminationId { get; set; }
        public int? LabId { get; set; }
        public string? Value { get; set; }
    }
}
