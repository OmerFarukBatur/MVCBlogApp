namespace MVCBlogApp.Application.ViewModels
{
    public class VM_CalcBMI
    {
        public int? Id { get; set; }
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public decimal? Result { get; set; }
    }
}
