using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class FoodHabits
    {
        [Key]
        public int ID { get; set; }
        public int MembersInformationID { get; set; }
        public string Breakfast { get; set; }
        public string BreakfastSnack { get; set; }
        public string Lunch { get; set; }
        public string LunchSnack { get; set; }
        public string Dinner { get; set; }
        public string DinnerSnack { get; set; }
        public virtual MembersInformation MembersInformation { get; set; }
    }
}
