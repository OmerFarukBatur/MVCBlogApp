using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class CalcBmh : BaseEntity
    {
        public string? Gender { get; set; }
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public string? Email { get; set; }
        public string? NameSurname { get; set; }
        public int? Age { get; set; }
        public decimal? Result { get; set; }
    }
}
