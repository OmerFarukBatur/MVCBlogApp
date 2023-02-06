using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public  class ImageBlog : BaseEntity
    {
        public int BlogID { get; set; }
        public bool IsCover { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public int StatusID { get; set; }

        

    }
}
