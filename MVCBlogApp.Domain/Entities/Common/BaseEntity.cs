namespace MVCBlogApp.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
