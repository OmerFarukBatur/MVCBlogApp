using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class References
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string UrlLink { get; set; }
        public string ImgUrl { get; set; }

        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public int StatusID { get; set; }

    }
}
