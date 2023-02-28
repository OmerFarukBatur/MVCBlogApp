namespace MVCBlogApp.Application.ViewModels
{
    public class VM_BlogType
    {
        public int? Id { get; set; }
        public string? TypeName { get; set; }
        public int? LangId { get; set; }
        public string? Language { get; set; }
        public List<VM_Language>? Languages { get; set; }
    }
}
