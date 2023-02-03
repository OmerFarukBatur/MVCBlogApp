using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class WorkshopType
    {
        public int ID { get; set; }

        public string WSTypeName { get; set; }

        public virtual IList<Workshop> WorkShop { get; set; }

        //****Örnekler******//
            //Online
            //Yüzyüze

    }
}
