using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
   public class ConsultancyFormType
    {
        [Key]
        public int ID { get; set; }

        public string ConsultancyFormTypeName { get; set; }

        public virtual IList<ConsultancyForm> ConsultancyForm { get; set; }


    }
}
