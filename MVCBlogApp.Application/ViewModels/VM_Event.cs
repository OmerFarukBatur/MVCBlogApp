namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Event
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? StartDatetime { get; set; }
        public DateTime? FinishDatetime { get; set; }
        public int? EventCategoryId { get; set; }
        public int? CreateUserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? EventCategoryName { get; set; }
        public string? StatusName { get; set; }
    }
}
