namespace MVCBlogApp.Application.ViewModels
{
    public class VM_ConsultancyForm
    {
        public int? Id { get; set; }
        public int? ConsultancyFormTypeId { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? ConsultancyFormTypeName { get; set; }
        public string? StatusName { get; set; }
    }
}
