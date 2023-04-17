namespace MVCBlogApp.Application.ViewModels
{
    public class VM_WorkshopEducation
    {
        public int? Id { get; set; }
        public int? WscategoryId { get; set; }
        public string? WsEducationName { get; set; }
        public int? StatusId { get; set; }
        public int? LangId { get; set; }

        public string? StatusName { get; set; }
        public string? Language { get; set; }
        public string? WscategoryName { get; set; }
    }
}
