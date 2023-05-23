namespace MVCBlogApp.Application.ViewModels
{
    public class VM_MembersInformation
    {
        public int? Id { get; set; }
        public int? MembersId { get; set; }
        public string? Name { get; set; } // 1
        public string? Surname { get; set; } // 1
        public DateTime? Birthdate { get; set; } // 1
        public string? Job { get; set; } // 1
        public string? PhoneNumber { get; set; } // 1
        public string? Email { get; set; } // 1
        public string? ImageUrl { get; set; }
        public string? HistoryOfWeigh { get; set; } // 2
        public bool? CpreviousDisease { get; set; } // 2
        public string? OneDaySummary { get; set; } // 2
        public string? TheQuantityConsumedWater { get; set; } // 3
        public string? TheQuantityConsumedTea { get; set; } // 3
        public string? TheQuantityConsumedCoffe { get; set; } // 3
        public string? TheQuantityConsumedFizzy { get; set; } // 3
        public string? TheQuantityConsumedAlchol { get; set; } // 3
        public bool? DoYouUseCigarettes { get; set; } // 3
        public bool? HaveYouGainedWeight { get; set; } // 3
        public string? FoodLocation { get; set; } // 3
        public string? FoodMade { get; set; } // 3
        public string? ManTheNeedForEatingVaries { get; set; } // 5
        public bool? DidYouGainWeightInTheArmy { get; set; } // 5
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
