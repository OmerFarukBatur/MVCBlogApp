using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment;
using MVCBlogApp.Application.Features.Queries.Member.MemberInfo.GetByIdMemberInfo;
using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.D_Appointment;
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
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

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
        private readonly IStorageService _storageService;
        private readonly IMembersInformationWriteRepository _membersInformationWriteRepository;
        private readonly IFoodHabitMoodWriteRepository _foodHabitMoodWriteRepository;
        private readonly IAllergyProducingFoodsWriteRepository _allergyProducingFoodsWriteRepository;
        private readonly IFoodTimeWriteRepository _foodTimeWriteRepository;
        private readonly IFemaleMentalStateWriteRepository _femaleMentalStateWriteRepository;
        private readonly IFoodHabitsWriteRepository _foodHabitsWriteRepository;
        private readonly IDiseasesFamilyMembersWriteRepository _diseasesFamilyMembersWriteRepository;
        private readonly IDiseasesWriteRepository _iseasesWriteRepository;
        private readonly IDiseasesDigestiveDisordersWriteRepository _diseasesDigestiveDisordersWriteRepository;
        private readonly IDiseasesCardiovascularWriteRepository _diseasesCardiovascularWriteRepository;
        private readonly IDiseasesDiabetesWriteRepository _diseasesDiabetesWriteRepository;
        private readonly ID_AppointmentReadRepository _d_AppointmentReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IAppointmentDetailReadRepository _appointmentDetailReadRepository;

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
            IDiseasesDiabetesReadRepository diseasesDiabetesReadRepository,
            IStorageService storageService,
            IMembersInformationWriteRepository membersInformationWriteRepository,
            IFoodHabitMoodWriteRepository foodHabitMoodWriteRepository,
            IAllergyProducingFoodsWriteRepository allergyProducingFoodsWriteRepository,
            IFoodTimeWriteRepository foodTimeWriteRepository,
            IFemaleMentalStateWriteRepository femaleMentalStateWriteRepository,
            IFoodHabitsWriteRepository foodHabitsWriteRepository,
            IDiseasesFamilyMembersWriteRepository diseasesFamilyMembersWriteRepository,
            IDiseasesWriteRepository iseasesWriteRepository,
            IDiseasesDigestiveDisordersWriteRepository diseasesDigestiveDisordersWriteRepository,
            IDiseasesCardiovascularWriteRepository diseasesCardiovascularWriteRepository,
            IDiseasesDiabetesWriteRepository diseasesDiabetesWriteRepository,
            ID_AppointmentReadRepository d_AppointmentReadRepository,
            IStatusReadRepository statusReadRepository,
            IUserReadRepository userReadRepository,
            IAppointmentDetailReadRepository appointmentDetailReadRepository)
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
            _storageService = storageService;
            _membersInformationWriteRepository = membersInformationWriteRepository;
            _foodHabitMoodWriteRepository = foodHabitMoodWriteRepository;
            _allergyProducingFoodsWriteRepository = allergyProducingFoodsWriteRepository;
            _foodTimeWriteRepository = foodTimeWriteRepository;
            _femaleMentalStateWriteRepository = femaleMentalStateWriteRepository;
            _foodHabitsWriteRepository = foodHabitsWriteRepository;
            _diseasesFamilyMembersWriteRepository = diseasesFamilyMembersWriteRepository;
            _iseasesWriteRepository = iseasesWriteRepository;
            _diseasesDigestiveDisordersWriteRepository = diseasesDigestiveDisordersWriteRepository;
            _diseasesCardiovascularWriteRepository = diseasesCardiovascularWriteRepository;
            _diseasesDiabetesWriteRepository = diseasesDiabetesWriteRepository;
            _d_AppointmentReadRepository = d_AppointmentReadRepository;
            _statusReadRepository = statusReadRepository;
            _userReadRepository = userReadRepository;
            _appointmentDetailReadRepository = appointmentDetailReadRepository;
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
                    ConsumedVegetables = x.ConsumedVegetables , //== null ? 2 : 2
                    CpreviousDisease = x.CpreviousDisease == null ? false : x.CpreviousDisease,
                    DidYouGainWeightInTheArmy = x.DidYouGainWeightInTheArmy == null ? false : x.DidYouGainWeightInTheArmy,
                    DoYouHaveHormonalProblem = x.DoYouHaveHormonalProblem,
                    DoYouUseVitaminAndMinerals = x.DoYouUseVitaminAndMinerals,
                    DoYouUseCigarettes = x.DoYouUseCigarettes == null ? false : x.DoYouUseCigarettes,
                    Email = x.Email,
                    FoodLocation = x.FoodLocation,
                    FoodMade = x.FoodMade,
                    HaveYouGainedWeight = x.HaveYouGainedWeight == null ? false : x.HaveYouGainedWeight,
                    GetDrugged = x.GetDrugged,
                    HistoryOfWeigh = x.HistoryOfWeigh,
                    HowDoYouFeel = x.HowDoYouFeel, //  == null ? 1 : 1
                    HowFrequencyOfActivity = x.HowFrequencyOfActivity , //== null ? 3 : 3
                    HowIsYourEnergy = x.HowIsYourEnergy, // == null ? 1 : 1
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
                    Surname = x.Surname,
                    DiseasesAcuteDiarrhea = false,
                    DiseasesCardiovascularHeart = false,
                    DiseasesCardiovascularHypertension = false,
                    DiseasesCardiovascularHypotension = false,
                    DiseasesCardiovascularPalpitation = false,
                    DiseasesChronicDiarrhea = false,
                    DiseasesColonCancer = false,
                    DiseasesConstipation = false,
                    DiseasesCrohn = false,
                    DiseasesDiabetesHypoglycemia = false,
                    DiseasesDiabetesTypeOneDiabetes = false,
                    DiseasesDiabetesTypeTwoDiabetes = false,
                    DiseasesDifaji = false,
                    DiseasesDyspepsia = false,
                    DiseasesFamilyCancer = false,
                    DiseasesFamilyDiabetes = false,
                    DiseasesFamilyEpilepsy = false,
                    DiseasesFamilyGout = false,
                    DiseasesFamilyHeart = false,
                    DiseasesFamilyHormone = false,
                    DiseasesFamilyTiroid = false,
                    DiseasesGas = false,
                    DiseasesGastricCancer = false,
                    DiseasesGastritis = false,
                    DiseasesHelicobacterPylori = false,
                    DiseasesHernia = false,
                    DiseasesIntestinalObstruction = false,
                    DiseasesIntestinalParasites = false,
                    DiseasesReflux = false,
                    DiseasesRegurgitation = false,
                    DiseasesSpasticColon = false,
                    DiseasesUlcer = false,
                    DiseasesUlcerativeColitis = false
                }).FirstOrDefaultAsync();

            if (vM_MemberAllDetail != null)
            {
                VM_FoodHabitMood? vM_FoodHabitMood = await _foodHabitMoodReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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

                VM_AllergyProducingFoods? vM_AllergyProducingFoods = await _allergyProducingsReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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

                VM_FoodTime? vM_FoodTime = await _foodTimeReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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

                VM_FemaleMentalState? vM_FemaleMentalState = await _emaleMentalStateReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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

                VM_FoodHabits? vM_FoodHabits = await _foodHabitsReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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

                List<VM_DiseasesFamilyMembers> vM_DiseasesFamilyMembers = await _iseasesFamilyMembersReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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
                    vM_MemberAllDetail.GetType().GetProperty(item.DiseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesDigestiveDisorders> vM_DiseasesDigestiveDisorders = await _iseasesDigestiveDisordersReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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
                    vM_MemberAllDetail.GetType().GetProperty(item.DiseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesCardiovascular> vM_DiseasesCardiovasculars = await _iseasesCardsReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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
                    vM_MemberAllDetail.GetType().GetProperty(item.DiseasesName).SetValue(vM_MemberAllDetail, true, null);
                }

                List<VM_DiseasesDiabetes> vM_DiseasesDiabetes = await _diseasesDiabetesReadRepository.GetWhere(x => x.MembersInformationId == vM_MemberAllDetail.Id)
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
                    vM_MemberAllDetail.GetType().GetProperty(item.DiseasesName).SetValue(vM_MemberAllDetail, true, null);
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

        public async Task<MemberInfoCreateCommandResponse> MemberInfoCreateAsync(MemberInfoCreateCommandRequest request)
        {
            var check = await _membersInformationReadRepository.GetWhere(x => x.MembersId == request.MembersId).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                MembersInformation membersInformation = new()
                {
                    Birthdate = request.Birthdate,
                    ConsumedVegetables = request.ConsumedVegetables,
                    CpreviousDisease = request.CpreviousDisease,
                    CreateDate = DateTime.Now,
                    DidYouGainWeightInTheArmy = request.DidYouGainWeightInTheArmy,
                    DoYouHaveHormonalProblem = request.DoYouHaveHormonalProblem,
                    DoYouUseCigarettes = request.DoYouUseCigarettes,
                    DoYouUseVitaminAndMinerals = request.DoYouUseVitaminAndMinerals,
                    Email = request.Email,
                    FoodLocation = request.FoodLocation,
                    FoodMade = request.FoodMade,
                    GetDrugged = request.GetDrugged,
                    HaveYouGainedWeight = request.HaveYouGainedWeight,
                    HistoryOfWeigh = request.HistoryOfWeigh,
                    TheQuantityConsumedWater = request.TheQuantityConsumedWater,
                    HowDoYouFeel = request.HowDoYouFeel,
                    HowFrequencyOfActivity = request.HowFrequencyOfActivity,
                    HowIsYourEnergy = request.HowIsYourEnergy,
                    IsBloodCoagulationDisorders = request.IsBloodCoagulationDisorders,
                    Job = request.Job,
                    ManTheNeedForEatingVaries = request.ManTheNeedForEatingVaries,
                    MembersId = request.MembersId,
                    Name = request.Name,
                    OneDaySummary = request.OneDaySummary,
                    OtherMessage = request.OtherMessage,
                    PhoneNumber = request.PhoneNumber,
                    Surname = request.Surname,
                    TheQuantityConsumedAlchol = request.TheQuantityConsumedAlchol,
                    TheQuantityConsumedCoffe = request.TheQuantityConsumedCoffe,
                    TheQuantityConsumedFizzy = request.TheQuantityConsumedFizzy,
                    TheQuantityConsumedTea = request.TheQuantityConsumedTea
                };

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("profile-image-files", request.FormFile);
                    membersInformation.ImageUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                await _membersInformationWriteRepository.AddAsync(membersInformation);
                await _membersInformationWriteRepository.SaveAsync();

                FoodHabitMood foodHabitMood = new()
                {
                    MembersInformationId = membersInformation.Id,
                    Happy = request.FoodHabitsMoodHappy,
                    Sad = request.FoodHabitsMoodSad,
                    Stress = request.FoodHabitsMoodStress,
                    Doomy = request.FoodHabitsMoodDoomy,
                    All = request.FoodHabitsMoodAll
                };

                await _foodHabitMoodWriteRepository.AddAsync(foodHabitMood);
                await _foodHabitMoodWriteRepository.SaveAsync();


                AllergyProducingFoods allergyProducingFoods = new()
                {
                    MembersInformationId = membersInformation.Id,
                    Like = request.AllergyProducingFoodsLike,
                    Dislike = request.AllergyProducingDislike,
                    Allergen = request.AllergyProducingFoodsAllergen
                };

                await _allergyProducingFoodsWriteRepository.AddAsync(allergyProducingFoods);
                await _allergyProducingFoodsWriteRepository.SaveAsync();


                FoodTime foodTime = new()
                {
                    MembersInformationId = membersInformation.Id,
                    WeekdayMorning = request.FoodTimeWeekdayMorning,
                    WeekdayNoon = request.FoodTimeWeekdayNoon,
                    WeekdayNight = request.FoodTimeWeekdayNight,
                    WeekendMorning = request.FoodTimeWeekendMorning,
                    WeekendNoon = request.FoodTimeWeekendNoon,
                    WeekendNight = request.FoodTimeWeekendNight
                };

                await _foodTimeWriteRepository.AddAsync(foodTime);
                await _foodTimeWriteRepository.SaveAsync();



                FemaleMentalState femaleMentalState = new()
                {
                    MembersInformationId = membersInformation.Id,
                    Menstruation = request.FemaleMentalStateMenstruation,
                    Menopause = request.FemaleMentalStateMenopause,
                    Gravidity = request.FemaleMentalStateGravidity,
                    BreastFeeding = request.FemaleMentalStateBreastFeeding,
                    IsBreastFeedingPeriod = request.FemaleMentalStateIsBreastFeedingPeriod,
                    IsMenstruatioRegular = request.FemaleMentalStateIsMenstruatioRegular,
                    IsHormontherapy = request.FemaleMentalStateIsHormontherapy,
                    IsGiveBirthTo = request.FemaleMentalStateIsGiveBirthTo
                };

                await _femaleMentalStateWriteRepository.AddAsync(femaleMentalState);
                await _femaleMentalStateWriteRepository.SaveAsync();


                FoodHabits foodHabits = new()
                {
                    MembersInformationId = membersInformation.Id,
                    Breakfast = request.FoodHabitsBreakfast,
                    BreakfastSnack = request.FoodHabitsBreakfastSnack,
                    Lunch = request.FoodHabitsLunch,
                    LunchSnack = request.FoodHabitsLunchSnack,
                    Dinner = request.FoodHabitsDinner,
                    DinnerSnack = request.FoodHabitsDinnerSnack
                };


                await _foodHabitsWriteRepository.AddAsync(foodHabits);
                await _foodHabitsWriteRepository.SaveAsync();

                /// type 1
                List<Diseases> diseasesFammily = await _iseasesReadRepository.GetWhere(x => x.Type == 1).ToListAsync();

                if (diseasesFammily != null)
                {
                    List<DiseasesFamilyMembers> diseasesFamilyMembers = new();

                    foreach (var item in diseasesFammily)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            diseasesFamilyMembers.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }
                    await _diseasesFamilyMembersWriteRepository.AddRangeAsync(diseasesFamilyMembers);
                    await _diseasesFamilyMembersWriteRepository.SaveAsync();
                }


                /// type 2
                List<Diseases> diseasesDigestion = await _iseasesReadRepository.GetWhere(x => x.Type == 2).ToListAsync();

                if (diseasesDigestion != null)
                {
                    List<DiseasesDigestiveDisorders> diseasesDigestiveDisorders = new();

                    foreach (var item in diseasesDigestion)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            diseasesDigestiveDisorders.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesDigestiveDisordersWriteRepository.AddRangeAsync(diseasesDigestiveDisorders);
                    await _diseasesDigestiveDisordersWriteRepository.SaveAsync();
                }

                /// type 3
                List<Diseases> diseasesCardiovascular = await _iseasesReadRepository.GetWhere(x => x.Type == 3).ToListAsync();

                if (diseasesCardiovascular != null)
                {
                    List<DiseasesCardiovascular> diseasesCardiovasculars = new();

                    foreach (var item in diseasesCardiovascular)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            diseasesCardiovasculars.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesCardiovascularWriteRepository.AddRangeAsync(diseasesCardiovasculars);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }

                /// type 4
                List<Diseases> diseasesDiabetes = await _iseasesReadRepository.GetWhere(x => x.Type == 4).ToListAsync();

                if (diseasesCardiovascular != null)
                {
                    List<DiseasesDiabetes> diseasesDiabetes1 = new();

                    foreach (var item in diseasesDiabetes)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            diseasesDiabetes1.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesDiabetesWriteRepository.AddRangeAsync(diseasesDiabetes1);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }


                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<MemberInfoUpdateCommandResponse> MemberInfoUpdateAsync(MemberInfoUpdateCommandRequest request)
        {
            MembersInformation? membersInformation = await _membersInformationReadRepository.GetWhere(x=> x.MembersId == request.MembersId).FirstOrDefaultAsync();

            if (membersInformation == null)
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunamamıştır.",
                    State = false
                };
            }
            else
            {
                membersInformation.Birthdate = request.Birthdate;
                membersInformation.ConsumedVegetables = request.ConsumedVegetables;
                membersInformation.CpreviousDisease = request.CpreviousDisease;
                membersInformation.DidYouGainWeightInTheArmy = request.DidYouGainWeightInTheArmy;
                membersInformation.DoYouHaveHormonalProblem = request.DoYouHaveHormonalProblem;
                membersInformation.DoYouUseCigarettes = request.DoYouUseCigarettes;
                membersInformation.DoYouUseVitaminAndMinerals = request.DoYouUseVitaminAndMinerals;
                membersInformation.Email = request.Email;
                membersInformation.FoodLocation = request.FoodLocation;
                membersInformation.FoodMade = request.FoodMade;
                membersInformation.GetDrugged = request.GetDrugged;
                membersInformation.HaveYouGainedWeight = request.HaveYouGainedWeight;
                membersInformation.HistoryOfWeigh = request.HistoryOfWeigh;
                membersInformation.TheQuantityConsumedWater = request.TheQuantityConsumedWater;
                membersInformation.HowDoYouFeel = request.HowDoYouFeel;
                membersInformation.HowFrequencyOfActivity = request.HowFrequencyOfActivity;
                membersInformation.HowIsYourEnergy = request.HowIsYourEnergy;
                membersInformation.IsBloodCoagulationDisorders = request.IsBloodCoagulationDisorders;
                membersInformation.Job = request.Job;
                membersInformation.ManTheNeedForEatingVaries = request.ManTheNeedForEatingVaries;
                membersInformation.Name = request.Name;
                membersInformation.OneDaySummary = request.OneDaySummary;
                membersInformation.OtherMessage = request.OtherMessage;
                membersInformation.PhoneNumber = request.PhoneNumber;
                membersInformation.Surname = request.Surname;
                membersInformation.TheQuantityConsumedAlchol = request.TheQuantityConsumedAlchol;
                membersInformation.TheQuantityConsumedCoffe = request.TheQuantityConsumedCoffe;
                membersInformation.TheQuantityConsumedFizzy = request.TheQuantityConsumedFizzy;
                membersInformation.TheQuantityConsumedTea = request.TheQuantityConsumedTea;
                membersInformation.UpdateDate = DateTime.Now;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("profile-image-files", request.FormFile);
                    membersInformation.ImageUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _membersInformationWriteRepository.Update(membersInformation);
                await _membersInformationWriteRepository.SaveAsync();

                FoodHabitMood? foodHabitMood = await _foodHabitMoodReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).FirstOrDefaultAsync();

                if (foodHabitMood != null)
                {
                    foodHabitMood.Happy = request.FoodHabitsMoodHappy;
                    foodHabitMood.Sad = request.FoodHabitsMoodSad;
                    foodHabitMood.Stress = request.FoodHabitsMoodStress;
                    foodHabitMood.Doomy = request.FoodHabitsMoodDoomy;
                    foodHabitMood.All = request.FoodHabitsMoodAll;

                    _foodHabitMoodWriteRepository.Update(foodHabitMood);
                    await _foodHabitMoodWriteRepository.SaveAsync();
                }
                else
                {
                    FoodHabitMood newFoodHabitMood = new()
                    {
                        MembersInformationId = membersInformation.Id,
                        Happy = request.FoodHabitsMoodHappy,
                        Sad = request.FoodHabitsMoodSad,
                        Stress = request.FoodHabitsMoodStress,
                        Doomy = request.FoodHabitsMoodDoomy,
                        All = request.FoodHabitsMoodAll
                    };

                    await _foodHabitMoodWriteRepository.AddAsync(newFoodHabitMood);
                    await _foodHabitMoodWriteRepository.SaveAsync();
                }

                AllergyProducingFoods? allergyProducingFoods = await _allergyProducingsReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).FirstOrDefaultAsync();

                if (allergyProducingFoods != null)
                {
                    allergyProducingFoods.Like = request.AllergyProducingFoodsLike;
                    allergyProducingFoods.Dislike = request.AllergyProducingDislike;
                    allergyProducingFoods.Allergen = request.AllergyProducingFoodsAllergen;

                    _allergyProducingFoodsWriteRepository.Update(allergyProducingFoods);
                    await _allergyProducingFoodsWriteRepository.SaveAsync();
                }
                else
                {
                    AllergyProducingFoods newAllergyProducingFoods = new()
                    {
                        MembersInformationId = membersInformation.Id,
                        Like = request.AllergyProducingFoodsLike,
                        Dislike = request.AllergyProducingDislike,
                        Allergen = request.AllergyProducingFoodsAllergen
                    };

                    await _allergyProducingFoodsWriteRepository.AddAsync(newAllergyProducingFoods);
                    await _allergyProducingFoodsWriteRepository.SaveAsync();
                }

                FoodTime? foodTime = await _foodTimeReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).FirstOrDefaultAsync();

                if (foodTime != null)
                {
                    foodTime.WeekdayMorning = request.FoodTimeWeekdayMorning;
                    foodTime.WeekdayNoon = request.FoodTimeWeekdayNoon;
                    foodTime.WeekdayNight = request.FoodTimeWeekdayNight;
                    foodTime.WeekendMorning = request.FoodTimeWeekendMorning;
                    foodTime.WeekendNoon = request.FoodTimeWeekendNoon;
                    foodTime.WeekendNight = request.FoodTimeWeekendNight;

                    _foodTimeWriteRepository.Update(foodTime);
                    await _foodTimeWriteRepository.SaveAsync();
                }
                else
                {
                    FoodTime newFoodTime = new()
                    {
                        MembersInformationId = membersInformation.Id,
                        WeekdayMorning = request.FoodTimeWeekdayMorning,
                        WeekdayNoon = request.FoodTimeWeekdayNoon,
                        WeekdayNight = request.FoodTimeWeekdayNight,
                        WeekendMorning = request.FoodTimeWeekendMorning,
                        WeekendNoon = request.FoodTimeWeekendNoon,
                        WeekendNight = request.FoodTimeWeekendNight
                    };

                    await _foodTimeWriteRepository.AddAsync(newFoodTime);
                    await _foodTimeWriteRepository.SaveAsync();
                }

                FemaleMentalState? femaleMentalState = await _emaleMentalStateReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).FirstOrDefaultAsync();

                if (femaleMentalState != null)
                {
                    femaleMentalState.Menstruation = request.FemaleMentalStateMenstruation;
                    femaleMentalState.Menopause = request.FemaleMentalStateMenopause;
                    femaleMentalState.Gravidity = request.FemaleMentalStateGravidity;
                    femaleMentalState.BreastFeeding = request.FemaleMentalStateBreastFeeding;
                    femaleMentalState.IsBreastFeedingPeriod = request.FemaleMentalStateIsBreastFeedingPeriod;
                    femaleMentalState.IsMenstruatioRegular = request.FemaleMentalStateIsMenstruatioRegular;
                    femaleMentalState.IsHormontherapy = request.FemaleMentalStateIsHormontherapy;
                    femaleMentalState.IsGiveBirthTo = request.FemaleMentalStateIsGiveBirthTo;

                    _femaleMentalStateWriteRepository.Update(femaleMentalState);
                    await _femaleMentalStateWriteRepository.SaveAsync();
                }
                else
                {
                    FemaleMentalState newFemaleMentalState = new()
                    {
                        MembersInformationId = membersInformation.Id,
                        Menstruation = request.FemaleMentalStateMenstruation,
                        Menopause = request.FemaleMentalStateMenopause,
                        Gravidity = request.FemaleMentalStateGravidity,
                        BreastFeeding = request.FemaleMentalStateBreastFeeding,
                        IsBreastFeedingPeriod = request.FemaleMentalStateIsBreastFeedingPeriod,
                        IsMenstruatioRegular = request.FemaleMentalStateIsMenstruatioRegular,
                        IsHormontherapy = request.FemaleMentalStateIsHormontherapy,
                        IsGiveBirthTo = request.FemaleMentalStateIsGiveBirthTo
                    };

                    await _femaleMentalStateWriteRepository.AddAsync(newFemaleMentalState);
                    await _femaleMentalStateWriteRepository.SaveAsync();
                }

                FoodHabits? foodHabits = await _foodHabitsReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).FirstOrDefaultAsync();

                if (foodHabits != null)
                {
                    foodHabits.Breakfast = request.FoodHabitsBreakfast;
                    foodHabits.BreakfastSnack = request.FoodHabitsBreakfastSnack;
                    foodHabits.Lunch = request.FoodHabitsLunch;
                    foodHabits.LunchSnack = request.FoodHabitsLunchSnack;
                    foodHabits.Dinner = request.FoodHabitsDinner;
                    foodHabits.DinnerSnack = request.FoodHabitsDinnerSnack;

                    _foodHabitsWriteRepository.Update(foodHabits);
                    await _foodHabitsWriteRepository.SaveAsync();
                }
                else
                {
                    FoodHabits newFoodHabits = new()
                    {
                        MembersInformationId = membersInformation.Id,
                        Breakfast = request.FoodHabitsBreakfast,
                        BreakfastSnack = request.FoodHabitsBreakfastSnack,
                        Lunch = request.FoodHabitsLunch,
                        LunchSnack = request.FoodHabitsLunchSnack,
                        Dinner = request.FoodHabitsDinner,
                        DinnerSnack = request.FoodHabitsDinnerSnack
                    };


                    await _foodHabitsWriteRepository.AddAsync(newFoodHabits);
                    await _foodHabitsWriteRepository.SaveAsync();
                }
                
                
                /// type 1
                List<DiseasesFamilyMembers> diseasesFamilyMembers = await _iseasesFamilyMembersReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).ToListAsync();

                if (diseasesFamilyMembers.Count() > 0)
                {
                    _diseasesFamilyMembersWriteRepository.RemoveRange(diseasesFamilyMembers);
                    await _diseasesFamilyMembersWriteRepository.SaveAsync();
                }

                
                List <Diseases> diseasesFammily = await _iseasesReadRepository.GetWhere(x => x.Type == 1).ToListAsync();

                if (diseasesFammily != null)
                {
                    List<DiseasesFamilyMembers> newDiseasesFamilyMembers = new();

                    foreach (var item in diseasesFammily)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            newDiseasesFamilyMembers.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }
                    await _diseasesFamilyMembersWriteRepository.AddRangeAsync(newDiseasesFamilyMembers);
                    await _diseasesFamilyMembersWriteRepository.SaveAsync();
                }


                /// type 2

                List<DiseasesDigestiveDisorders> diseasesDigestiveDisorders = await _iseasesDigestiveDisordersReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).ToListAsync();

                if (diseasesDigestiveDisorders != null)
                {
                    _diseasesDigestiveDisordersWriteRepository.RemoveRange(diseasesDigestiveDisorders);
                    await _diseasesDigestiveDisordersWriteRepository.SaveAsync();
                }

                List <Diseases> diseasesDigestion = await _iseasesReadRepository.GetWhere(x => x.Type == 2).ToListAsync();

                if (diseasesDigestion != null)
                {
                    List<DiseasesDigestiveDisorders> newDiseasesDigestiveDisorders = new();

                    foreach (var item in diseasesDigestion)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            newDiseasesDigestiveDisorders.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesDigestiveDisordersWriteRepository.AddRangeAsync(newDiseasesDigestiveDisorders);
                    await _diseasesDigestiveDisordersWriteRepository.SaveAsync();
                }

                /// type 3

                List<DiseasesCardiovascular> diseasesCardiovasculars = await _iseasesCardsReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).ToListAsync();

                if (diseasesCardiovasculars != null)
                {
                    _diseasesCardiovascularWriteRepository.RemoveRange(diseasesCardiovasculars);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }

                List <Diseases> diseasesCardiovascular = await _iseasesReadRepository.GetWhere(x => x.Type == 3).ToListAsync();

                if (diseasesCardiovascular != null)
                {
                    List<DiseasesCardiovascular> newDiseasesCardiovasculars = new();

                    foreach (var item in diseasesCardiovascular)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            newDiseasesCardiovasculars.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesCardiovascularWriteRepository.AddRangeAsync(newDiseasesCardiovasculars);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }

                /// type 4

                List<DiseasesDiabetes> diseasesDiabetess = await _diseasesDiabetesReadRepository.GetWhere(x => x.MembersInformationId == membersInformation.Id).ToListAsync();

                if (diseasesDiabetess != null)
                {
                    _diseasesDiabetesWriteRepository.RemoveRange(diseasesDiabetess);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }

                List <Diseases> diseasesDiabetes = await _iseasesReadRepository.GetWhere(x => x.Type == 4).ToListAsync();

                if (diseasesCardiovascular != null)
                {
                    List<DiseasesDiabetes> newDiseasesDiabetes = new();

                    foreach (var item in diseasesDiabetes)
                    {
                        bool dValue = Convert.ToBoolean(request.GetType().GetProperty(item.DiseasesName).GetValue(request, null));

                        if (dValue)
                        {
                            newDiseasesDiabetes.Add(new()
                            {
                                DiseasesId = item.Id,
                                MembersInformationId = membersInformation.Id
                            });
                        }
                    }

                    await _diseasesDiabetesWriteRepository.AddRangeAsync(newDiseasesDiabetes);
                    await _diseasesCardiovascularWriteRepository.SaveAsync();
                }


                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        #endregion

        #region MemberAppointment

        public async Task<GetByIdMemberAllAppointmentQueryResponse> GetByIdMemberAllAppointmentAsync(int id)
        {
            List<VM_D_Appointment> vM_D_Appointments = await _d_AppointmentReadRepository.GetWhere(x=> x.MembersId == id)
                .Join(_userReadRepository.GetAll(), app => app.UserId, user => user.Id, (app, user) => new { app, user })
                .Join(_statusReadRepository.GetAll(), appio => appio.app.StatusId, st => st.Id, (appio, st) => new { appio, st })
                .Select(x => new VM_D_Appointment
                {
                    Id = x.appio.app.Id,
                    Price = x.appio.app.Price,
                    AppointmentDate = x.appio.app.AppointmentDate,
                    StatusName = x.st.StatusName,
                    UserName = x.appio.user.Username,
                    CreateDate = x.appio.app.CreateDate                    
                }).ToListAsync();

            return new()
            {
                D_Appointments = vM_D_Appointments
            };
        }



        #endregion
    }
}
