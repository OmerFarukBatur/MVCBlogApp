namespace MVCBlogApp.Application.ViewModels
{
    public class VM_Press
    {
        public int? Id  { get; set; }
        public string? Title { get; set; }
        public string? UrlRoot { get; set; }
        public string? MetaTitle { get; set; } 
        public string? MetaKey { get; set; }
        public string? MetaDescription { get; set; }
        public string? UrlLink { get; set; }
        public int? NewsPaperId { get; set; }
        public int? PressTypeId { get; set; }
        public string? ImageUrl { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public int? LangId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }       
        
        


        public string? NewsPaperName { get; set; }
        public string? StatusName { get; set; }
        public string? Language { get; set; }
        public string? PressTypeName { get; set; }
    }
}
