using MVCBlogApp.Domain.Entities.Common;

namespace MVCBlogApp.Domain.Entities
{
    public class FoodHabits : BaseEntity
    {
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
