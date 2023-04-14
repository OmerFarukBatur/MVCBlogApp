﻿namespace MVCBlogApp.Application.ViewModels
{
    public class VM_MembersInformation
    {
        public int? Id { get; set; }
        public int? MembersId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Job { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? HistoryOfWeigh { get; set; }
        public bool? CpreviousDisease { get; set; }
        public string? OneDaySummary { get; set; }
        public string? TheQuantityConsumedWater { get; set; }
        public string? TheQuantityConsumedTea { get; set; }
        public string? TheQuantityConsumedCoffe { get; set; }
        public string? TheQuantityConsumedFizzy { get; set; }
        public string? TheQuantityConsumedAlchol { get; set; }
        public bool? DoYouUseCigarettes { get; set; }
        public bool? HaveYouGainedWeight { get; set; }
        public string? FoodLocation { get; set; }
        public string? FoodMade { get; set; }
        public string? ManTheNeedForEatingVaries { get; set; }
        public bool? DidYouGainWeightInTheArmy { get; set; }
        public string? IsBloodCoagulationDisorders { get; set; }
        public string? DoYouHaveHormonalProblem { get; set; }
        public int? HowDoYouFeel { get; set; }
        public int? HowIsYourEnergy { get; set; }
        public int? HowFrequencyOfActivity { get; set; }
        public int? ConsumedVegetables { get; set; }
        public string? GetDrugged { get; set; }
        public string? DoYouUseVitaminAndMinerals { get; set; }
        public string? OtherMessage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string? MemberNameSurname { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Size { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}