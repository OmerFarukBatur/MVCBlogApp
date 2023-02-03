using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class FoodTime
    {
        [Key]
        public int ID { get; set; }
        public int MembersInformationID { get; set; }
        public string WeekdayMorning { get; set; }
        public string WeekdayNoon { get; set; }
        public string WeekdayNight { get; set; }
        public string WeekendMorning { get; set; }
        public string WeekendNoon { get; set; }
        public string WeekendNight { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
    }
}
