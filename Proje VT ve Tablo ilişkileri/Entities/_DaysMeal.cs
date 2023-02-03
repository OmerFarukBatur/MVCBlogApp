using System;
using System.Collections.Generic;
using System.Text;

namespace TK_WebProject.Entities.Entities
{
    public class _DaysMeal
    {
        public int ID { get; set; }

        public int DietListID { get; set; }
        public int DaysID { get; set; }
        public int MealID { get; set; }
        public TimeSpan TimeInterval { get; set; }
        public string Description { get; set; }

        public virtual Days Days { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual DietList DietList { get; set; }
    }
}
