using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Enums;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionUpdate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTUpdate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetByIdConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyForm.GetAllConsultancyForm;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetAllCFT;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetByIdCFT;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetAllMemberAppointment;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdDietList;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetByIdLab;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberNutritionist.GetAllMemberNutritionist;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MembersInformation.GetByIdMembersInformation;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;
using MVCBlogApp.Application.Repositories._DaysMeal;
using MVCBlogApp.Application.Repositories._Examination;
using MVCBlogApp.Application.Repositories.AllergyProducingFoods;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Application.Repositories.DietList;
using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Application.Repositories.DiseasesCardiovascular;
using MVCBlogApp.Application.Repositories.DiseasesDiabetes;
using MVCBlogApp.Application.Repositories.DiseasesDigestiveDisorders;
using MVCBlogApp.Application.Repositories.DiseasesFamilyMembers;
using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Application.Repositories.FemaleMentalState;
using MVCBlogApp.Application.Repositories.FoodHabitMood;
using MVCBlogApp.Application.Repositories.FoodHabits;
using MVCBlogApp.Application.Repositories.FoodTime;
using MVCBlogApp.Application.Repositories.Lab;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Meal;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Application.Repositories.MembersInformation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Persistence.Repositories.Auth;
using MVCBlogApp.Persistence.Repositories.ConsultancyFormType;
using System.IO;
using System.Linq;

namespace MVCBlogApp.Persistence.Services
{
    public class UserIslemleriService : IUserIslemleriService
    {
        private readonly IMembersAuthReadRepository _membersAuthReadRepository;
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IMembersWriteRepository _membersWriteRepository;
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IConfessionReadRepository _confessionReadRepository;
        private readonly IConfessionWriteRepository _confessionWriteRepository;
        private readonly IConsultancyFormTypeReadRepository _consultancyFormTypeReadRepository;
        private readonly IConsultancyFormTypeWriteRepository _consultancyFormTypeWriteRepository;
        private readonly IConsultancyFormReadRepository _consultancyFormReadRepository;
        private readonly ID_AppointmentReadRepository _appointmentReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IAppointmentDetailReadRepository _appointmentDetailReadRepository;
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
        private readonly ILabReadRepository _labReadRepository;
        private readonly I_ExaminationReadRepository __examinationReadRepository;
        private readonly IExaminationReadRepository _examinationReadRepository;
        private readonly I_DaysMealReadRepository _daysMealReadRepository;
        private readonly IDaysReadRepository _daysReadRepository;
        private readonly IMealReadRepository _mealReadRepository;
        private readonly IDietListReadRepository _ietListReadRepository;

        public UserIslemleriService(
            IMembersAuthReadRepository membersAuthReadRepository,
            IMembersReadRepository membersReadRepository,
            IMembersWriteRepository membersWriteRepository,
            IAuthService authService,
            IMailService mailService,
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IConfessionReadRepository confessionReadRepository,
            IConfessionWriteRepository confessionWriteRepository,
            IConsultancyFormTypeReadRepository consultancyFormTypeReadRepository,
            IConsultancyFormTypeWriteRepository consultancyFormTypeWriteRepository,
            IConsultancyFormReadRepository consultancyFormReadRepository,
            ID_AppointmentReadRepository appointmentReadRepository,
            IUserReadRepository userReadRepository,
            IAppointmentDetailReadRepository appointmentDetailReadRepository,
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
            ILabReadRepository labReadRepository,
            I_ExaminationReadRepository __ExaminationReadRepository,
            IExaminationReadRepository examinationReadRepository,
            I_DaysMealReadRepository daysMealReadRepository,
            IDaysReadRepository daysReadRepository,
            IMealReadRepository mealReadRepository,
            IDietListReadRepository ietListReadRepository)
        {
            _membersAuthReadRepository = membersAuthReadRepository;
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
            _authService = authService;
            _mailService = mailService;
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _confessionReadRepository = confessionReadRepository;
            _confessionWriteRepository = confessionWriteRepository;
            _consultancyFormTypeReadRepository = consultancyFormTypeReadRepository;
            _consultancyFormTypeWriteRepository = consultancyFormTypeWriteRepository;
            _consultancyFormReadRepository = consultancyFormReadRepository;
            _appointmentReadRepository = appointmentReadRepository;
            _userReadRepository = userReadRepository;
            _appointmentDetailReadRepository = appointmentDetailReadRepository;
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
            _labReadRepository = labReadRepository;
            __examinationReadRepository = __ExaminationReadRepository;
            _examinationReadRepository = examinationReadRepository;
            _daysMealReadRepository = daysMealReadRepository;
            _daysReadRepository = daysReadRepository;
            _mealReadRepository = mealReadRepository;
            _ietListReadRepository = ietListReadRepository;
        }



        #region Member

        public async Task<GetUserCreateItemsQueryResponse> GetUserCreateItemsAsync()
        {
            List<VM_UserAuth> vM_UserAuths = await _membersAuthReadRepository
                .GetAll()
                .Select(x => new VM_UserAuth
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    MembersAuthName = x.MembersAuthName
                }).ToListAsync();

            return new()
            {
                UserAuths = vM_UserAuths
            };
        }

        public async Task<GetAllUserQueryResponse> GetAllUserAsync()
        {
            List<VM_Member> vM_Members = await _membersReadRepository
                .GetAll()
                .Join(_membersAuthReadRepository.GetAll(), user => user.MembersAuthId, ma => ma.Id, (user, ma) => new { user, ma })
                .Select(x => new VM_Member
                {
                    Id = x.user.Id,
                    Address = x.user.Address,
                    CreateDate = x.user.CreateDate,
                    CreateUserId = x.user.CreateUserId,
                    Email = x.user.Email,
                    IsActive = x.user.IsActive,
                    Lacation = x.user.Lacation,
                    MemberAuthName = x.ma.MembersAuthName,
                    MembersAuthId = x.user.MembersAuthId,
                    NameSurname = x.user.NameSurname,
                    Phone = x.user.Phone
                }).ToListAsync();

            return new()
            {
                Members = vM_Members
            };
        }

        public async Task<GetByIdUserQueryResponse> GetByIdUserAsync(int id)
        {
            VM_Member? vM_Member = await _membersReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Member
                {
                    Id = x.Id,
                    Address = x.Address,
                    Email = x.Email,
                    IsActive = x.IsActive,
                    Lacation = x.Lacation,
                    MembersAuthId = x.MembersAuthId,
                    NameSurname = x.NameSurname,
                    Phone = x.Phone
                }).FirstOrDefaultAsync();

            if (vM_Member != null)
            {
                List<VM_UserAuth> vM_UserAuths = await _membersAuthReadRepository
                .GetAll()
                .Select(x => new VM_UserAuth
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    MembersAuthName = x.MembersAuthName
                }).ToListAsync();

                return new()
                {
                    Member = vM_Member,
                    UserAuths = vM_UserAuths,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Member = null,
                    UserAuths = null,
                    Message = "Bu bilgilere ait kayıt bulunamamaktadır.",
                    State = false
                };
            }

        }

        public async Task<UserCreateCommandResponse> UserCreateAsync(UserCreateCommandRequest request)
        {
            var memberCheck = await _membersReadRepository
                .GetWhere(x => x.Email.Trim().ToLower() == request.Email.Trim().ToLower() || x.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()).ToListAsync();

            if (memberCheck.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                (byte[] passwordSalt, byte[] passwordHash) = _authService.CreatePasswordHash(request.Password);
                Members members = new()
                {
                    Address = request.Address,
                    Email = request.Email,
                    IsActive = request.IsActive,
                    Lacation = request.Lacation,
                    MembersAuthId = request.MembersAuthId,
                    NameSurname = request.NameSurname,
                    Phone = request.Phone,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    CreateDate = DateTime.Now,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                await _membersWriteRepository.AddAsync(members);
                await _membersWriteRepository.SaveAsync();

                if (request.IsActive)
                {
                    // await _mailService.SendMailAsync(request.Email, request.NameSurname, request.Password);
                }

                return new()
                {
                    Message = "Bilgiler başarıyla kayıt edilmiştir.",
                    State = true
                };
            }
        }

        public async Task<UserUpdateCommandResponse> UserUpdateAsync(UserUpdateCommandRequest request)
        {
            Members members = await _membersReadRepository.GetByIdAsync(request.Id);

            if (members != null)
            {
                if (request.Password != "" && request.Password != null)
                {
                    (byte[] passwordSalt, byte[] passwordHash) = _authService.CreatePasswordHash(request.Password);
                    members.PasswordSalt = passwordSalt;
                    members.PasswordHash = passwordHash;
                }

                members.Address = request.Address;
                members.Email = request.Email;
                members.IsActive = request.IsActive;
                members.NameSurname = request.NameSurname;
                members.Phone = request.Phone;
                members.Lacation = request.Lacation;
                members.MembersAuthId = request.MembersAuthId;


                if (request.IsActive)
                {
                    // await _mailService.SendMailAsync(request.Email, request.NameSurname, request.Password);
                }

                _membersWriteRepository.Update(members);
                await _membersWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgiye ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<UserDeleteCommandResponse> UserDeleteAsync(int id)
        {
            Members members = await _membersReadRepository.GetByIdAsync(id);

            if (members != null)
            {
                members.IsActive = false;
                _membersWriteRepository.Update(members);
                await _membersWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bu bilgilere ait kayıt bulunamamıştır."
                };
            }
        }

        #endregion

        #region MemberNutritionist

        public async Task<GetAllMemberNutritionistQueryResponse> GetAllMemberNutritionistAsync()
        {

            List<VM_MembersInformation> vM_MembersInformations = await _membersInformationReadRepository.GetAll()
                .Join(_appointmentDetailReadRepository.GetAll(), mem => mem.MembersId, app => app.MembersId, (mem, app) => new { mem, app })
                .Join(_membersReadRepository.GetAll(), memInfo => memInfo.mem.MembersId, mb => mb.Id, (memInfo, mb) => new { memInfo, mb })
                .Join(_appointmentReadRepository.GetAll(), memInformation => memInformation.memInfo.mem.MembersId, appo => appo.MembersId, (memInformation, appo) => new { memInformation, appo })
                .Select(x => new VM_MembersInformation
                {
                    Id = x.memInformation.memInfo.mem.Id,
                    Birthdate = x.memInformation.memInfo.mem.Birthdate,
                    Job = x.memInformation.memInfo.mem.Job,
                    MemberNameSurname = x.memInformation.mb.NameSurname,
                    Weight = x.memInformation.memInfo.app.Weight,
                    Size = x.memInformation.memInfo.app.Size,
                    AppointmentDate = x.appo.AppointmentDate
                }).ToListAsync();


            return new()
            {
                MembersInformations = vM_MembersInformations
            };
        }

        #endregion

        #region MembersInformation

        public async Task<GetByIdMIQueryResponse> GetByIdMIAsync(int id)
        {
            VM_MemberAllDetail? vM_MemberAllDetail = await _membersInformationReadRepository.GetWhere(x => x.MembersId == id)
                .Select(x => new VM_MemberAllDetail
                {
                    Id = x.Id,
                    MembersId = x.MembersId,
                    Birthdate = x.Birthdate,
                    ConsumedVegetables = x.ConsumedVegetables == 1 ? "3 - 4 Porsiyon" : x.ConsumedVegetables == 2 ? "1 - 2 Porsiyon" : "1 veya hiç",
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
                    HowDoYouFeel = x.HowDoYouFeel == 1 ? "Çok sağlıklı" : x.HowDoYouFeel == 2 ? "Şöyle - Böyle" : "Kötü",
                    HowFrequencyOfActivity = x.HowFrequencyOfActivity == 1 ? "Düzenli yürüyüş / spor" : x.HowFrequencyOfActivity == 2 ? "Arada bir yürüyüş / spor" : "Hiç hareket yok",
                    HowIsYourEnergy = x.HowIsYourEnergy == 1 ? "Çok iyi" : x.HowIsYourEnergy == 2 ? "İyi" : "Kötü",
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

        #endregion

        #region MemberAppointment

        public async Task<GetAllMemberAppointmentQueryResponse> GetAllMemberAppointmentAsync()
        {
            List<VM_D_Appointment> vM_D_Appointments = await _appointmentReadRepository.GetAll()
                .Join(_membersReadRepository.GetAll(), ap => ap.MembersId, mem => mem.Id, (ap, mem) => new { ap, mem })
                .Join(_userReadRepository.GetAll(), app => app.ap.UserId, us => us.Id, (app, us) => new { app, us })
                .Join(_statusReadRepository.GetAll(), appo => appo.app.ap.StatusId, st => st.Id, (appo, st) => new { appo, st })
                .Select(x => new VM_D_Appointment
                {
                    Id = x.appo.app.ap.Id,
                    AppointmentDate = x.appo.app.ap.AppointmentDate,
                    Subject = x.appo.app.ap.Subject,
                    Price = x.appo.app.ap.Price,
                    Description = x.appo.app.ap.Description,
                    UserName = x.appo.us.Username,
                    MemeberName = x.appo.app.mem.NameSurname,
                    StatusName = x.st.StatusName,
                    CreateDate = x.appo.app.ap.CreateDate
                }).ToListAsync();

            return new()
            {
                D_Appointments = vM_D_Appointments
            };
        }

        public async Task<GetByIdAppointmentDetailQueryResponse> GetByIdAppointmentDetailAsync(int id)
        {
            VM_AppointmentDetail? vM_AppointmentDetail = await _appointmentDetailReadRepository.GetWhere(x => x.AppointmentId == id)
                .Join(_membersReadRepository.GetAll(), app => app.MembersId, mem => mem.Id, (app, mem) => new { app, mem })
                .Select(x => new VM_AppointmentDetail
                {
                    Id = x.app.Id,
                    AppointmentId = x.app.Id,
                    History = x.app.History,
                    MembersId = x.app.Id,
                    Diagnosis = x.app.Diagnosis,
                    OilRate = x.app.OilRate,
                    Size = x.app.Size,
                    Treatment = x.app.Treatment,
                    Weight = x.app.Weight,
                    MemberName = x.mem.NameSurname
                }).FirstOrDefaultAsync();

            if (vM_AppointmentDetail != null)
            {
                return new()
                {
                    AppointmentDetail = vM_AppointmentDetail,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    AppointmentDetail = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<GetByIdLabQueryResponse> GetByIdLabAsync(int id)
        {
            VM_Lab? vM_Lab = await _labReadRepository.GetWhere(x => x.AppointmentDetailId == id)
                .Join(_membersReadRepository.GetAll(),la=> la.MembersId, mem=> mem.Id,(la,mem)=> new {la,mem})
                .Join(_userReadRepository.GetAll(),lab=> lab.la.UsersId, use => use.Id, (lab, use) => new {lab,use})
                .Select(x => new VM_Lab
                {
                    Id = x.lab.la.Id,
                    AppointmentDetailId = x.lab.la.AppointmentDetailId,
                    Description = x.lab.la.Description,
                    LabDateTime = x.lab.la.LabDateTime,
                    MembersId = x.lab.la.MembersId,
                    Title = x.lab.la.Title,
                    UsersId = x.lab.la.UsersId,
                    MemberName = x.lab.mem.NameSurname,
                    UserName = x.use.Username
                }).FirstOrDefaultAsync();

            if (vM_Lab != null)
            {
                List<VM_Examination> vM_Examinations = await _examinationReadRepository.GetAll()
                    .Select(x => new VM_Examination
                    {
                        Id = x.Id,
                        ExaminatioName = x.ExaminatioName
                    }).ToListAsync();

                List<_Examination> __examination = await __examinationReadRepository.GetWhere(x => x.LabId == vM_Lab.Id).ToListAsync();

                foreach (var item in __examination)
                {
                    foreach (var __item in vM_Examinations)
                    {
                        if (item.ExaminationId == __item.Id)
                        {
                            __item.Selected = true;
                        }
                        else
                        {
                            __item.Selected = false;
                        }
                    }
                }

                return new()
                {
                    Examinations = vM_Examinations,
                    Lab = vM_Lab,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Examinations = null,
                    Lab = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<GetByIdDietListQueryResponse> GetByIdDietListAsync(int id)
        {
            VM_DietList? vM_DietList = await _ietListReadRepository.GetWhere(x => x.AppointmentDetailId == id)
                .Select(x => new VM_DietList
                {
                    Id = x.Id,
                    AppointmentDetailId = x.AppointmentDetailId,
                    Description = x.Description,
                    Title = x.Title,
                    UserId = x.UserId,
                    CreateDate = x.CreateDate
                }).FirstOrDefaultAsync();

            if (vM_DietList != null)
            {
                List<VM__DaysMeal> vM__DaysMeal = await _daysMealReadRepository.GetWhere(x => x.DietListId == id)
                    .Join(_daysReadRepository.GetAll(),dm=> dm.DaysId, day=> day.Id,(dm,day)=> new {dm,day})
                    .Join(_mealReadRepository.GetAll(),dmMe=> dmMe.dm.MealId, meal=> meal.Id,(dmMe,meal)=> new {dmMe,meal})
                    .Select(x => new VM__DaysMeal
                    {
                        Id = x.dmMe.dm.Id,
                        DaysId = x.dmMe.dm.DaysId,
                        Description = x.dmMe.dm.Description,
                        DietListId = x.dmMe.dm.DietListId,
                        MealId = x.dmMe.dm.MealId,
                        TimeInterval = x.dmMe.dm.TimeInterval,
                        DaysName = x.dmMe.day.DayName,
                        MealName = x.meal.MealName
                    }).ToListAsync();                

                return new()
                { 
                    DaysMeals = vM__DaysMeal,
                    DietList = vM_DietList,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    DaysMeals = null,
                    DietList = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        #endregion

        #region Confession

        public async Task<GetConfessionCreateItemsQueryResponse> GetConfessionCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                Statuses = allStatuses,
                Languages = vM_Languages
            };
        }

        public async Task<GetAllConfessionQueryResponse> GetAllConfessionAsync()
        {
            List<VM_Confession> vM_Confessions = await _confessionReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), co => co.LangId, lg => lg.Id, (co, lg) => new { co, lg })
                .Join(_statusReadRepository.GetAll(), con => con.co.StatusId, st => st.Id, (con, st) => new { con, st })
                .Select(x => new VM_Confession
                {
                    Id = x.con.co.Id,
                    MemberConfession = x.con.co.MemberConfession,
                    MemberName = x.con.co.MemberName,
                    CreateDatetime = x.con.co.CreateDatetime,
                    Language = x.con.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                Confessions = vM_Confessions,
            };
        }

        public async Task<ConfessionCreateCommandResponse> ConfessionCreateAsync(ConfessionCreateCommandRequest request)
        {
            Confession confession = new()
            {
                CreateDatetime = DateTime.Now,
                IsAprove = request.IsAprove,
                IsRead = request.IsRead,
                IsVisible = request.IsVisible,
                LangId = request.LangId,
                MemberConfession = request.MemberConfession,
                MemberName = request.MemberName,
                StatusId = request.StatusId,
            };

            await _confessionWriteRepository.AddAsync(confession);
            await _confessionWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetByIdConfessionQueryResponse> GetByIdConfessionAsync(int id)
        {
            VM_Confession? vM_Confession = await _confessionReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Confession
                {
                    Id = x.Id,
                    IsAprove = x.IsAprove,
                    IsRead = x.IsRead,
                    IsVisible = x.IsVisible,
                    LangId = x.LangId,
                    MemberConfession = x.MemberConfession,
                    MemberName = x.MemberName,
                    StatusId = x.StatusId
                }).FirstOrDefaultAsync();

            if (vM_Confession != null)
            {
                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                    .Select(x => new AllStatus
                    {
                        Id = x.Id,
                        StatusName = x.StatusName
                    }).ToListAsync();

                return new()
                {
                    Statuses = allStatuses,
                    Languages = vM_Languages,
                    Confession = vM_Confession,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Languages = null,
                    Confession = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<ConfessionUpdateCommandResponse> ConfessionUpdateAsync(ConfessionUpdateCommandRequest request)
        {
            Confession confession = await _confessionReadRepository.GetByIdAsync(request.Id);

            if (confession != null)
            {
                confession.IsAprove = request.IsAprove;
                confession.MemberConfession = request.MemberConfession;
                confession.MemberName = request.MemberName;
                confession.IsRead = request.IsRead;
                confession.LangId = request.LangId;
                confession.StatusId = request.StatusId;
                confession.IsVisible = request.IsVisible;

                _confessionWriteRepository.Update(confession);
                await _confessionWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<ConfessionDeleteCommandResponse> ConfessionDeleteAsync(int id)
        {
            Confession confession = await _confessionReadRepository.GetByIdAsync(id);

            if (confession != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                confession.StatusId = statusId;

                _confessionWriteRepository.Update(confession);
                await _confessionWriteRepository.SaveAsync();

                return new()
                {
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion

        #region ConsultancyFormType

        public async Task<GetAllCFTQueryResponse> GetAllCFTAsync()
        {
            List<VM_ConsultancyFormType> vM_ConsultancyFormTypes = await _consultancyFormTypeReadRepository.GetAll()
                .Select(x => new VM_ConsultancyFormType
                {
                    Id = x.Id,
                    ConsultancyFormTypeName = x.ConsultancyFormTypeName
                }).ToListAsync();

            return new()
            {
                ConsultancyFormTypes = vM_ConsultancyFormTypes,
            };
        }

        public async Task<CFTCreateCommandResponse> CFTCreateAsync(CFTCreateCommandRequest request)
        {
            ConsultancyFormType consultancyFormType = new()
            {
                ConsultancyFormTypeName = request.ConsultancyFormTypeName
            };

            await _consultancyFormTypeWriteRepository.AddAsync(consultancyFormType);
            await _consultancyFormTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla tamamlandı.",
                State = true
            };
        }

        public async Task<GetByIdCFTQueryResponse> GetByIdCFTAsync(int id)
        {
            VM_ConsultancyFormType? vM_ConsultancyFormType = await _consultancyFormTypeReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_ConsultancyFormType
                {
                    Id = x.Id,
                    ConsultancyFormTypeName = x.ConsultancyFormTypeName
                }).FirstOrDefaultAsync();

            if (vM_ConsultancyFormType != null)
            {
                return new()
                {
                    ConsultancyFormType = vM_ConsultancyFormType,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    ConsultancyFormType = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<CFTUpdateCommandResponse> CFTUpdateAsync(CFTUpdateCommandRequest request)
        {
            ConsultancyFormType consultancyFormType = await _consultancyFormTypeReadRepository.GetByIdAsync(request.Id);

            if (consultancyFormType != null)
            {
                consultancyFormType.ConsultancyFormTypeName = request.ConsultancyFormTypeName;

                _consultancyFormTypeWriteRepository.Update(consultancyFormType);
                await _consultancyFormTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<CFTDeleteCommandResponse> CFTDeleteAsync(int id)
        {
            ConsultancyFormType consultancyFormType = await _consultancyFormTypeReadRepository.GetByIdAsync(id);

            if (consultancyFormType != null)
            {
                _consultancyFormTypeWriteRepository.Remove(consultancyFormType);
                await _consultancyFormTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion

        #region ConsultancyForm

        public async Task<GetAllConsultancyFormQueryResponse> GetAllConsultancyFormAsync()
        {
            List<VM_ConsultancyForm> vM_ConsultancyForms = await _consultancyFormReadRepository.GetAll()
                 .Join(_consultancyFormTypeReadRepository.GetAll(), co => co.ConsultancyFormTypeId, cft => cft.Id, (co, cft) => new { co, cft })
                 .Join(_statusReadRepository.GetAll(), con => con.co.StatusId, st => st.Id, (con, st) => new { con, st })
                 .Select(x => new VM_ConsultancyForm
                 {
                     Id = x.con.co.Id,
                     CreateDate = x.con.co.CreateDate,
                     Email = x.con.co.Email,
                     Message = x.con.co.Message,
                     NameSurname = x.con.co.NameSurname,
                     Phone = x.con.co.Phone,
                     Subject = x.con.co.Subject,
                     ConsultancyFormTypeName = x.con.cft.ConsultancyFormTypeName,
                     StatusName = x.st.StatusName,
                 }).ToListAsync();

            return new()
            {
                ConsultancyForms = vM_ConsultancyForms
            };
        }
        
        #endregion
    }
}
