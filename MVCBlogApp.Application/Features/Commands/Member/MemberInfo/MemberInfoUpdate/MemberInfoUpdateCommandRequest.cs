using MediatR;
using Microsoft.AspNetCore.Http;

namespace MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate
{
    public class MemberInfoUpdateCommandRequest : IRequest<MemberInfoUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int MembersId { get; set; }
        public string Name { get; set; } // 1
        public string Surname { get; set; } // 1
        public DateTime Birthdate { get; set; } // 1
        public string Job { get; set; } // 1
        public string PhoneNumber { get; set; } // 1
        public string Email { get; set; } // 1
        public IFormFileCollection? FormFile { get; set; }         ///
        public string HistoryOfWeigh { get; set; } // 2
        public bool CpreviousDisease { get; set; } // 2
        public string OneDaySummary { get; set; } // 2
        public string TheQuantityConsumedWater { get; set; } // 3
        public string TheQuantityConsumedTea { get; set; } // 3
        public string TheQuantityConsumedCoffe { get; set; } // 3
        public string TheQuantityConsumedFizzy { get; set; } // 3
        public string TheQuantityConsumedAlchol { get; set; } // 3
        public bool DoYouUseCigarettes { get; set; } // 3
        public bool HaveYouGainedWeight { get; set; } // 3
        public string FoodLocation { get; set; } // 3
        public string FoodMade { get; set; } // 3
        public string ManTheNeedForEatingVaries { get; set; } // 5
        public bool DidYouGainWeightInTheArmy { get; set; } // 5
        public string IsBloodCoagulationDisorders { get; set; }
        public string DoYouHaveHormonalProblem { get; set; }
        public int HowDoYouFeel { get; set; } // int to string
        public int HowIsYourEnergy { get; set; } // int to string
        public int HowFrequencyOfActivity { get; set; } // int to string
        public int ConsumedVegetables { get; set; } // int to string
        public string GetDrugged { get; set; }
        public string DoYouUseVitaminAndMinerals { get; set; }
        public string OtherMessage { get; set; }


        public bool DiseasesFamilyDiabetes { get; set; }
        public bool DiseasesFamilyHeart { get; set; }
        public bool DiseasesFamilyTiroid { get; set; }
        public bool DiseasesFamilyHormone { get; set; }
        public bool DiseasesFamilyCancer { get; set; }
        public bool DiseasesFamilyGout { get; set; }
        public bool DiseasesFamilyEpilepsy { get; set; }

        public string FoodHabitsBreakfast { get; set; }
        public string FoodHabitsBreakfastSnack { get; set; }
        public string FoodHabitsLunch { get; set; }
        public string FoodHabitsLunchSnack { get; set; }
        public string FoodHabitsDinner { get; set; }
        public string FoodHabitsDinnerSnack { get; set; }


        public string AllergyProducingFoodsLike { get; set; }
        public string AllergyProducingDislike { get; set; }
        public string AllergyProducingFoodsAllergen { get; set; }


        public string FoodTimeWeekdayMorning { get; set; }
        public string FoodTimeWeekdayNoon { get; set; }
        public string FoodTimeWeekdayNight { get; set; }
        public string FoodTimeWeekendMorning { get; set; }
        public string FoodTimeWeekendNoon { get; set; }
        public string FoodTimeWeekendNight { get; set; }

        public bool FoodHabitsMoodSad { get; set; }
        public bool FoodHabitsMoodStress { get; set; }
        public bool FoodHabitsMoodDoomy { get; set; }
        public bool FoodHabitsMoodHappy { get; set; }
        public bool FoodHabitsMoodAll { get; set; }

        public string FemaleMentalStateMenstruation { get; set; }
        public string FemaleMentalStateMenopause { get; set; }
        public string FemaleMentalStateGravidity { get; set; }
        public string FemaleMentalStateBreastFeeding { get; set; }
        public string FemaleMentalStateIsBreastFeedingPeriod { get; set; }
        public string FemaleMentalStateIsMenstruatioRegular { get; set; }
        public string FemaleMentalStateIsHormontherapy { get; set; }
        public string FemaleMentalStateIsGiveBirthTo { get; set; }


        public bool DiseasesReflux { get; set; }
        public bool DiseasesDifaji { get; set; }
        public bool DiseasesRegurgitation { get; set; }
        public bool DiseasesHernia { get; set; }
        public bool DiseasesDyspepsia { get; set; }
        public bool DiseasesHelicobacterPylori { get; set; }
        public bool DiseasesGastritis { get; set; }
        public bool DiseasesUlcer { get; set; }
        public bool DiseasesGastricCancer { get; set; }
        public bool DiseasesIntestinalObstruction { get; set; }
        public bool DiseasesAcuteDiarrhea { get; set; }
        public bool DiseasesChronicDiarrhea { get; set; }
        public bool DiseasesConstipation { get; set; }
        public bool DiseasesSpasticColon { get; set; }
        public bool DiseasesGas { get; set; }
        public bool DiseasesIntestinalParasites { get; set; }
        public bool DiseasesUlcerativeColitis { get; set; }
        public bool DiseasesCrohn { get; set; }
        public bool DiseasesColonCancer { get; set; }

        public bool DiseasesCardiovascularHypertension { get; set; }
        public bool DiseasesCardiovascularHypotension { get; set; }
        public bool DiseasesCardiovascularPalpitation { get; set; }
        public bool DiseasesCardiovascularHeart { get; set; }

        public bool DiseasesDiabetesHypoglycemia { get; set; }
        public bool DiseasesDiabetesTypeOneDiabetes { get; set; }
        public bool DiseasesDiabetesTypeTwoDiabetes { get; set; }
    }
}