namespace MVCBlogApp.Application.ViewModels
{
    public class VM_FoodHabits
    {
        public int? Id { get; set; }
        public int? MembersInformationId { get; set; }
        public string? Breakfast { get; set; }
        public string? BreakfastSnack { get; set; }
        public string? Lunch { get; set; }
        public string? LunchSnack { get; set; }
        public string? Dinner { get; set; }
        public string? DinnerSnack { get; set; }
    }
}
