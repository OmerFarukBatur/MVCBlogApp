using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Enums;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate;
using MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo;
using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Application.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Application.Repositories.DiseasesDiabetes;
using MVCBlogApp.Application.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Application.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Application.Repositories.FemaleMentalState;
using MVCBlogApp.Application.Repositories.FoodHabitMood;
using MVCBlogApp.Application.Repositories.FoodHabits;
using MVCBlogApp.Application.Repositories.FoodTime;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersInformation;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Persistence.Services
{
    public class MemberGeneralProcess : IMemberGeneralProcess
    {
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IMembersInformationReadRepository _membersInformationReadRepository;
        private readonly IFoodHabitMoodReadRepository _foodHabitMoodReadRepository;
        private readonly IAllergyProducingFoodsReadRepository _allergyProducingsReadRepository;
        private readonly IFoodTimeReadRepository _foodTimeReadRepository;
        private readonly IFemaleMentalStateReadRepository _emaleMentalStateReadRepository;
        private readonly IFoodHabitsReadRepository _foodHabitsReadRepository;
        private readonly IDiseasesFamilyMembersReadRepository _iseasesFamilyMembersReadRepository;
        private readonly IDiseasesReadRepository _iseasesReadRepository;
        private readonly IDiseasesDigestiveDisordersReadRepository _iseasesDigestiveDisordersReadRepository;
        private readonly IDiseasesCardiovascularReadRepository _iseasesCardsReadRepository;
        private readonly IDiseasesDiabetesReadRepository _diseasesDiabetesReadRepository;

        public MemberGeneralProcess(
            IMembersReadRepository membersReadRepository, 
            IMembersInformationReadRepository membersInformationReadRepository, 
            IFoodHabitMoodReadRepository foodHabitMoodReadRepository, 
            IAllergyProducingFoodsReadRepository allergyProducingsReadRepository, 
            IFoodTimeReadRepository foodTimeReadRepository, 
            IFemaleMentalStateReadRepository emaleMentalStateReadRepository, 
            IFoodHabitsReadRepository foodHabitsReadRepository, 
            IDiseasesFamilyMembersReadRepository iseasesFamilyMembersReadRepository, 
            IDiseasesReadRepository iseasesReadRepository, 
            IDiseasesDigestiveDisordersReadRepository iseasesDigestiveDisordersReadRepository, 
            IDiseasesCardiovascularReadRepository iseasesCardsReadRepository, 
            IDiseasesDiabetesReadRepository diseasesDiabetesReadRepository)
        {
            _membersReadRepository = membersReadRepository;
            _membersInformationReadRepository = membersInformationReadRepository;
            _foodHabitMoodReadRepository = foodHabitMoodReadRepository;
            _allergyProducingsReadRepository = allergyProducingsReadRepository;
            _foodTimeReadRepository = foodTimeReadRepository;
            _emaleMentalStateReadRepository = emaleMentalStateReadRepository;
            _foodHabitsReadRepository = foodHabitsReadRepository;
            _iseasesFamilyMembersReadRepository = iseasesFamilyMembersReadRepository;
            _iseasesReadRepository = iseasesReadRepository;
            _iseasesDigestiveDisordersReadRepository = iseasesDigestiveDisordersReadRepository;
            _iseasesCardsReadRepository = iseasesCardsReadRepository;
            _diseasesDiabetesReadRepository = diseasesDiabetesReadRepository;
        }


        #region MemberInfo

        public async Task<GetByIdMemberInfoQueryResponse> GetByIdMemberAsync(int id)
        {
            VM_MemberAllDetailODataType? vM_MemberAllDetail = await _membersInformationReadRepository.GetWhere(x => x.MembersId == id)
                .Select(x => new VM_MemberAllDetailODataType
                {
                    Id = x.Id,
                    MembersId = x.MembersId,
                    Birthdate = x.Birthdate,
                    ConsumedVegetables = x.ConsumedVegetables == null ? 2 : 2, //
                    CpreviousDisease = x.CpreviousDisease == null ? null : x.CpreviousDisease,
                    DidYouGainWeightInTheArmy = x.DidYouGainWeightInTheArmy == null ? null : x.DidYouGainWeightInTheArmy,
                    DoYouHaveHormonalProblem = x.DoYouHaveHormonalProblem,
                    DoYouUseVitaminAndMinerals = x.DoYouUseVitaminAndMinerals,
                    DoYouUseCigarettes = x.DoYouUseCigarettes == null ? null : x.DoYouUseCigarettes,
                    Email = x.Email,
                    FoodLocation = x.FoodLocation,
                    FoodMade = x.FoodMade,
                    HaveYouGainedWeight = x.HaveYouGainedWeight == null ? null : x.HaveYouGainedWeight,
                    GetDrugged = x.GetDrugged,
                    HistoryOfWeigh = x.HistoryOfWeigh,
                    HowDoYouFeel = x.HowDoYouFeel == null ? 1 : 1 , // 
                    HowFrequencyOfActivity = x.HowFrequencyOfActivity == null ? 3 : 3, //
                    HowIsYourEnergy = x.HowIsYourEnergy == null ? 1 : 1, //
                    IsBloodCoagulationDisorders = x.IsBloodCoagulationDisorders,
                    ManTheNeedForEatingVaries = x.ManTheNeedForEatingVaries,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Job = x.Job,
                    OneDaySummary = x.OneDaySummary,
                    OtherMessage = x.OtherMessage,
                    PhoneNumber = x.PhoneNumber,
                    TheQuantityConsumedAlchol = x.TheQuantityConsumedAlchol,
                    TheQuantityConsumedCoffe = x.TheQuantityConsumedCoffe,
                    TheQuantityConsumedFizzy = x.TheQuantityConsumedFizzy,
                    TheQuantityConsumedTea = x.TheQuantityConsumedTea,
                    TheQuantityConsumedWater = x.TheQuantityConsumedWater,
                    Surname = x.Surname
                }).FirstOrDefaultAsync();

            if (vM_MemberAllDetail != null)
            {
                VM_FoodHabitMood? vM_FoodHabitMood = await _foodHabitMoodReadRepository.GetWhere(x => x.MembersInformationId == id)
                    .Select(x => new VM_FoodHabitMood
                    {
                        Happy = x.Happy == null ? false : x.Happy,
                        Sad = x.Sad == null ? false : x.Sad,
                        Stress = x.Stress == null ? false : x.Stress,
                        Doomy = x.Doomy == null ? false : x.Doomy,
                        All = x.All == null ? false : x.All
                    }).FirstOrDefaultAsync();

                if (vM_FoodHabitMood != null)
                {
                    vM_MemberAllDetail.FoodHabitsMoodHappy = vM_FoodHabitMood.Happy;
                    vM_MemberAllDetail.FoodHabitsMoodSad = vM_FoodHabitMood.Sad;
                    vM_MemberAllDetail.FoodHabitsMoodStress = vM_FoodHabitMood.Stress;
                    vM_MemberAllDetail.FoodHabitsMoodDoomy = vM_FoodHabitMood.Doomy;
                    vM_MemberAllDetail.FoodHabitsMoodAll = vM_FoodHabitMood.All;
                }

                VM_AllergyProducingFoods? vM_AllergyProducingFoods = await _allergyProducingsReadRepository.GetWhere(x => x.MembersInformationId == id)
                    .Select(x => new VM_AllergyProducingFoods
                    {
                        Like = x.Like == null ? "" : x.Like,
                        Dislike = x.Dislike == null ? "" : x.Dislike,
                        Allergen = x.Allergen == null ? "" : x.Allergen
                    }).FirstOrDefaultAsync();

                if (vM_AllergyProducingFoods != null)
                {
                    vM_MemberAllDetail.AllergyProducingFoodsLike = vM_AllergyProducingFoods.Like;
                    vM_MemberAllDetail.AllergyProducingDislike = vM_AllergyProducingFoods.Dislike;
                    vM_MemberAllDetail.AllergyProducingFoodsAllergen = vM_AllergyProducingFoods.Allergen;
                }

                VM_FoodTime? vM_FoodTime = await _foodTimeReadRepository.GetWhere(x => x.MembersInformationId == id)
                    .Select(x => new VM_FoodTime
                    {
                        WeekdayMorning = x.WeekdayMorning == null ? "" : x.WeekdayMorning,
                        WeekdayNoon = x.WeekdayNoon == null ? "" : x.WeekdayNoon,
                        WeekdayNight = x.WeekdayNight == null ? "" : x.WeekdayNight,
                        WeekendMorning = x.WeekendMorning == null ? "" : x.WeekendMorning,
                        WeekendNoon = x.WeekendNoon == null ? "" : x.WeekendNoon,
                        WeekendNight = x.WeekendNight == null ? "" : x.WeekendNight
                    }).FirstOrDefaultAsync();

                if (vM_FoodTime != null)
                {
                    vM_MemberAllDetail.FoodTimeWeekdayMorning = vM_FoodTime.WeekdayMorning;
                    vM_MemberAllDetail.FoodTimeWeekdayNoon = vM_FoodTime.WeekdayNoon;
                    vM_MemberAllDetail.FoodTimeWeekdayNight = vM_FoodTime.WeekdayNight;
                    vM_MemberAllDetail.FoodTimeWeekendMorning = vM_FoodTime.WeekendMorning;
                    vM_MemberAllDetail.FoodTimeWeekendNoon = vM_FoodTime.WeekendNoon;
                    vM_MemberAllDetail.FoodTimeWeekendNight = vM_FoodTime.WeekendNight;
                }

                VM_FemaleMentalState? vM_FemaleMentalState = await _emaleMentalStateReadRepository.GetWhere(x => x.MembersInformationId == id)
                    .Select(x => new VM_FemaleMentalState
                    {
                        Menstruation = x.Menstruation == null ? "" : x.Menstruation,
                        Menopause = x.Menopause == null ? "" : x.Menopause,
                        Gravidity = x.Gravidity == null ? "" : x.Gravidity,
                        BreastFeeding = x.BreastFeeding == null ? "" : x.BreastFeeding,
                        IsBreastFeedingPeriod = x.IsBreastFeedingPeriod == null ? "" : x.IsBreastFeedingPeriod,
                        IsMenstruatioRegular = x.IsMenstruatioRegular == null ? "" : x.IsMenstruatioRegular,
                        IsHormontherapy = x.IsHormontherapy == null ? "" : x.IsHormontherapy,
                        IsGiveBirthTo = x.IsGiveBirthTo == null ? "" : x.IsGiveBirthTo
                    }).FirstOrDefaultAsync();

                if (vM_FemaleMentalState != null)
                {
                    vM_MemberAllDetail.FemaleMentalStateMenstruation = vM_FemaleMentalState.Menstruation;
                    vM_MemberAllDetail.FemaleMentalStateMenopause = vM_FemaleMentalState.Menopause;
                    vM_MemberAllDetail.FemaleMentalStateGravidity = vM_FemaleMentalState.Gravidity;
                    vM_MemberAllDetail.FemaleMentalStateBreastFeeding = vM_FemaleMentalState.BreastFeeding;
                    vM_MemberAllDetail.FemaleMentalStateIsBreastFeedingPeriod = vM_FemaleMentalState.IsBreastFeedingPeriod;
                    vM_MemberAllDetail.FemaleMentalStateIsMenstruatioRegular = vM_FemaleMentalState.IsMenstruatioRegular;
                    vM_MemberAllDetail.FemaleMentalStateIsHormontherapy = vM_FemaleMentalState.IsHormontherapy;
                    vM_MemberAllDetail.FemaleMentalStateIsGiveBirthTo = vM_FemaleMentalState.IsGiveBirthTo;
                }

                VM_FoodHabits? vM_FoodHabits = await _foodHabitsReadRepository.GetWhere(x => x.MembersInformationId == id)
                    .Select(x => new VM_FoodHabits
                    {
                        Breakfast = x.Breakfast == null ? "" : x.Breakfast,
                        BreakfastSnack = x.BreakfastSnack == null ? "" : x.BreakfastSnack,
                        Lunch = x.Lunch == null ? "" : x.Lunch,
                        LunchSnack = x.LunchSnack == null ? "" : x.LunchSnack,
                        Dinner = x.Dinner == null ? "" : x.Dinner,
                        DinnerSnack = x.DinnerSnack == null ? "" : x.DinnerSnack
                    }).FirstOrDefaultAsync();

                if (vM_FoodHabits != null)
                {
                    vM_MemberAllDetail.FoodHabitsBreakfast = vM_FoodHabits.Breakfast;
                    vM_MemberAllDetail.FoodHabitsBreakfastSnack = vM_FoodHabits.BreakfastSnack;
                    vM_MemberAllDetail.FoodHabitsLunch = vM_FoodHabits.Lunch;
                    vM_MemberAllDetail.FoodHabitsLunchSnack = vM_FoodHabits.LunchSnack;
                    vM_MemberAllDetail.FoodHabitsDinner = vM_FoodHabits.Dinner;
                    vM_MemberAllDetail.FoodHabitsDinnerSnack = vM_FoodHabits.DinnerSnack;
                }

                List<VM_DiseasesFamilyMembers> vM_DiseasesFamilyMembers = await _iseasesFamilyMembersReadRepository.GetAll()
                    .Join(_iseasesReadRepository.GetAll(), fa => fa.DiseasesId, di => di.Id, (fa, di) => new { fa, di })
                    .Select(x => new VM_DiseasesFamilyMembers
                    {
                        Id = x.fa.Id,
                        DiseasesId = x.di.Id,
                        DiseasesName = x.di.DiseasesName,
                        MembersInformationId = x.fa.MembersInformationId,
                        Type = x.di.Type
                    }).ToListAsync();

                foreach (var item in vM_DiseasesFamilyMembers)
                {
                    string diseasesName = ((DiseasesTypes)item.DiseasesId).ToString();
                    vM_MemberAllDetail.GetType().GetProperty(diseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesDigestiveDisorders> vM_DiseasesDigestiveDisorders = await _iseasesDigestiveDisordersReadRepository.GetAll()
                    .Join(_iseasesReadRepository.GetAll(), fa => fa.DiseasesId, di => di.Id, (fa, di) => new { fa, di })
                    .Select(x => new VM_DiseasesDigestiveDisorders
                    {
                        Id = x.fa.Id,
                        DiseasesId = x.di.Id,
                        DiseasesName = x.di.DiseasesName,
                        MembersInformationId = x.fa.MembersInformationId,
                        Type = x.di.Type
                    }).ToListAsync();

                foreach (var item in vM_DiseasesDigestiveDisorders)
                {
                    string diseasesName = ((DiseasesTypes)item.DiseasesId).ToString();
                    vM_MemberAllDetail.GetType().GetProperty(diseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesCardiovascular> vM_DiseasesCardiovasculars = await _iseasesCardsReadRepository.GetAll()
                    .Join(_iseasesReadRepository.GetAll(), fa => fa.DiseasesId, di => di.Id, (fa, di) => new { fa, di })
                    .Select(x => new VM_DiseasesCardiovascular
                    {
                        Id = x.fa.Id,
                        DiseasesId = x.di.Id,
                        DiseasesName = x.di.DiseasesName,
                        MembersInformationId = x.fa.MembersInformationId,
                        Type = x.di.Type
                    }).ToListAsync();

                foreach (var item in vM_DiseasesCardiovasculars)
                {
                    string diseasesName = ((DiseasesTypes)item.DiseasesId).ToString();
                    vM_MemberAllDetail.GetType().GetProperty(diseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesDiabetes> vM_DiseasesDiabetes = await _diseasesDiabetesReadRepository.GetAll()
                    .Join(_iseasesReadRepository.GetAll(), fa => fa.DiseasesId, di => di.Id, (fa, di) => new { fa, di })
                    .Select(x => new VM_DiseasesDiabetes
                    {
                        Id = x.fa.Id,
                        DiseasesId = x.di.Id,
                        DiseasesName = x.di.DiseasesName,
                        MembersInformationId = x.fa.MembersInformationId,
                        Type = x.di.Type
                    }).ToListAsync();

                foreach (var item in vM_DiseasesDiabetes)
                {
                    string diseasesName = ((DiseasesTypes)item.DiseasesId).ToString();
                    vM_MemberAllDetail.GetType().GetProperty(diseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                return new()
                {
                    MemberAllDetail = vM_MemberAllDetail,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    MemberAllDetail = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public Task<MemberInfoCreateCommandResponse> MemberInfoCreateAsync(MemberInfoCreateCommandRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
