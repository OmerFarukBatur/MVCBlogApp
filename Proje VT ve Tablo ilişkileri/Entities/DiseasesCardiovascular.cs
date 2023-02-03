using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class DiseasesCardiovascular
    {
        [Key]
        public int ID { get; set; }
        public int MembersInformationID { get; set; }
        public int DiseasesID { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
        public virtual Diseases Diseases { get; set; }
    }
}
