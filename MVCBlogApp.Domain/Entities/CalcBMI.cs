using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class CalcBMI : BaseEntity
    {
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public decimal? Result { get; set; }
    }
}
