namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Influencer
    {
        public int? Id { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanySector { get; set; }
        public string? Message { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public int? StatusId { get; set; }

        public string? StatusName { get; set; }
    }
}
