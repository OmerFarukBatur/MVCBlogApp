namespace MVCBlogApp.Application.ViewModels
{
    public class VM_AllDietList
    {
        public int? Id { get; set; }
        public int? AppointmentDetailId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? _DaysMealId { get; set; }
        public int? DaysId { get; set; }
        public TimeSpan? TimeInterval { get; set; }
        public int? MealId { get; set; }
        public string? _DaysMealDescription { get; set; }

        public string? Diagnosis { get; set; }
        public string? MemberName { get; set; }
    }
}
