namespace MVCBlogApp.Application.ViewModels
{
    public class VM__DaysMeal
    {
        public int? Id { get; set; }
        public int? DietListId { get; set; }
        public int? DaysId { get; set; }
        public TimeSpan? TimeInterval { get; set; }
        public int? MealId { get; set; }
        public string? Description { get; set; }

        public string? DaysName { get; set; }
        public string? MealName { get; set; }
        public string? Title { get; set; }
    }
}
