using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class MembersAuth
    {
        [Key]
        public int ID { get; set; }
        public string MembersAuthName { get; set; }

        public bool IsActive { get; set; }

        public virtual IList<Members> Members { get; set; }


    }
}
