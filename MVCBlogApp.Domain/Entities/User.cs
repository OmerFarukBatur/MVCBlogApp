using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class User : BaseEntity
    {
        
        public string? UserName { get; set; }

        
        public string? Email { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public int? AuthID { get; set; }

        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserID { get; set; }

        //İlişkiler
        public virtual Auth Auth { get; set; }
        public virtual TaylanK TaylanK { get; set; }
        public virtual IList<Blog> Blog { get; set; }
        public virtual IList<Lab> Lab { get; set; }
        public virtual IList<AppointmentDetail> AppointmentDetail { get; set; }
        public virtual IList<DietList> DietLists { get; set; }
    }
}
