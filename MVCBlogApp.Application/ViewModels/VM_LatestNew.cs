namespace MVCBlogApp.Application.ViewModels
{
    public class VM_LatestNew
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? UrlRoot { get; set; }
        public string? CoveCoverImgUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
