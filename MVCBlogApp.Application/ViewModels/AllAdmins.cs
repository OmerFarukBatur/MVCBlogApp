using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.ViewModels
{
    public class AllAdmins
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AuthName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserID { get; set; }
    }
}
