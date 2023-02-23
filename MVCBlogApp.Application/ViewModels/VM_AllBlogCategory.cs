using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.ViewModels
{
    public class VM_AllBlogCategory
    {
        public int Id { get; set; }
        public string CatgoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Status Status { get; set; }
        public Languages Languages { get; set; }
    }
}
