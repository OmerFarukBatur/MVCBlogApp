using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Auth
    {
        [Key]
        public int ID { get; set; }
        public string AuthName { get; set; }


        //İlişkiler
        public virtual IList<User> User { get; set; }
    }
}
