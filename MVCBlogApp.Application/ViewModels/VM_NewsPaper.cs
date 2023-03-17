namespace MVCBlogApp.Application.ViewModels
{
    public class VM_NewsPaper
    {
        public int? Id { get; set; }
        public string? NewsPaperName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? StatusName { get; set; }
        public string? Language { get; set; }
    }
}
