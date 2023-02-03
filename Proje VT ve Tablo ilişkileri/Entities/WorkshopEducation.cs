using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class WorkshopEducation
    {
        public int ID { get; set; }

        public int WSCategoryID { get; set; }
        public string WsEducationName { get; set; }
        public int StatusID { get; set; }
        public int LangID { get; set; }

        public virtual Languages Languages { get; set; }
        public virtual IList<WorkshopCategory> WorkshopCategory { get; set; }
        public virtual IList<Workshop> Workshop { get; set; }

    }
}
