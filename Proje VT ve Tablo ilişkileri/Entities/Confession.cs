using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class Confession
    {
        public int ID { get; set; }
        public string MemberConfession { get; set; }
        public string MemberName { get; set; }
        public bool IsVisible { get; set; }
        public bool IsAprove { get; set; }
        public bool IsRead { get; set; }
        public int StatusID { get; set; }
        public DateTime CreateDatetime { get; set; }

    }
}
