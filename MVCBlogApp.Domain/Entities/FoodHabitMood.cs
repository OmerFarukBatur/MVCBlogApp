﻿using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FoodHabitMood : BaseEntity
    {
        public int? MembersInformationId { get; set; }
        public bool? Sad { get; set; }
        public bool? Stress { get; set; }
        public bool? Doomy { get; set; }
        public bool? Happy { get; set; }
        public bool? All { get; set; }
    }
}
