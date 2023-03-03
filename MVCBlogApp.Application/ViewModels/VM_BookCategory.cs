namespace MVCBlogApp.Application.ViewModels
{
    public class VM_BookCategory
    {
        public int? Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }
        public string? StatusName { get; set; }
        public string? Language { get; set; }

        public bool? SelectedState { get; set; }
    }
}
