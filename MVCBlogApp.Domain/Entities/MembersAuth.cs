﻿using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class MembersAuth : BaseEntity
    {
       public string MembersAuthName { get; set; }

        public virtual IList<Members> Members { get; set; }


    }
}
