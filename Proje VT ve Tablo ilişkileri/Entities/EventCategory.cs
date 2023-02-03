using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class EventCategory
    {
        [Key]
        public int ID { get; set; }

        public string EventCategoryName { get; set; }
        public string EventClassName { get; set; }

        public virtual IList<Event> Event { get; set; }

    }
}
