using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class MasterRoot
    {
        [Key]
        public int ID { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string UrlRoot { get; set; }


       

    }
}
