using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class CalcOptimum : BaseEntity
    {
        public string Gender { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public int Age { get; set; }
        public decimal Result1 { get; set; }
        public decimal Result2 { get; set; }
        public decimal Result3 { get; set; }
        public decimal Result4 { get; set; }
    }
}
