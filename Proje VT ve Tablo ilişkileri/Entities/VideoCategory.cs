using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class VideoCategory
    {
        [Key]
        public int ID { get; set; }
        public string VideoCategoryName { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Video> Videos { get; set; }
    }
}
