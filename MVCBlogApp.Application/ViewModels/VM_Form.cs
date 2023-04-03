namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Form
    {
        public int? Id { get; set; }
        public string? FormName { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public int? LangId { get; set; }

        public string? Language { get; set; }
    }
}
