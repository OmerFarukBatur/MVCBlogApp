using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class CalcPulse : BaseEntity
    {
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public decimal? ResultMax { get; set; }
        public decimal? ResultMin { get; set; }
    }
}
