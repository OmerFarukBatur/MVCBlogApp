﻿using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class EventCategory : BaseEntity
    {
        public string? EventCategoryName { get; set; }
        public string? EventClassName { get; set; }

        public virtual IList<Event> Event { get; set; }
    }
}
