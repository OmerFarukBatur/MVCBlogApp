using MVCBlogApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Domain.Entities
{
    public class Auth : BaseEntity
    {
        public string AuthName { get; set; }


        //İlişkiler
        public virtual IList<User> User { get; set; }
    }
}
