using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class ArticleCategory
    {
        [Key]
        public int ID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public int? StatusID { get; set; }
        public int? LangID { get; set; }

        public virtual Status Status { get; set; }
        public virtual IList<Article> Article { get; set; }
    }
}
