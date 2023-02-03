using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class FoodHabitMood
    {
        [Key]
        public int ID { get; set; }
        public int MembersInformationID { get; set; }
        public bool? Sad { get; set; }
        public bool? Stress { get; set; }
        public bool? Doomy { get; set; }
        public bool? Happy { get; set; }
        public bool? All { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }

    }
}
