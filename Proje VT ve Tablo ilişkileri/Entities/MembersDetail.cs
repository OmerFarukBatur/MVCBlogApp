using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class MembersDetail
    {
        [Key]
        public int ID { get; set; }
        public int MembersID { get; set; }

        public int size { get; set; }
        public decimal Weight { get; set; }
        public decimal FatRate { get; set; }

        public DateTime BirtDate { get; set; }

        public virtual Members Members { get; set; }

    }
}
