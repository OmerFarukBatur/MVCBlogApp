using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class WorkshopCategory
    {
        public int ID { get; set; }
        public string WSCategoryName { get; set; }
        public int LangID { get; set; }

        public virtual WorkshopEducation WorkshopEducation { get; set; }
    }
}
