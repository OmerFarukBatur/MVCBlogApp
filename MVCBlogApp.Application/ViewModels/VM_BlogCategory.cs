namespace MVCBlogApp.Application.ViewModels
{
    public class VM_BlogCategory
    {
        public int? ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }
    }
}
