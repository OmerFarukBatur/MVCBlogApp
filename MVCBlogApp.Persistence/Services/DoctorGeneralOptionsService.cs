using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Examination.ExaminationUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Meal.MealUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetAllDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetByIdDietList;
using MVCBlogApp.Application.Features.Queries.Doctor.DietList.GetDietListCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetAllExamination;
using MVCBlogApp.Application.Features.Queries.Doctor.Examination.GetByIdExamination;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetAllMeals;
using MVCBlogApp.Application.Features.Queries.Doctor.Meal.GetByIdMeal;
using MVCBlogApp.Application.Repositories._DaysMeal;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Application.Repositories.DietList;
using MVCBlogApp.Application.Repositories.Examination;
using MVCBlogApp.Application.Repositories.Meal;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class DoctorGeneralOptionsService : IDoctorGeneralOptionsService
    {
        private readonly IDaysReadRepository _daysReadRepository;
        private readonly IDaysWriteRepository _daysWriteRepository;
        private readonly IMealReadRepository _mealReadRepository;
        private readonly IMealWriteRepository _mealWriteRepository;
        private readonly IDietListReadRepository _ietListReadRepository;
        private readonly IDietListWriteRepository _ietListWriteRepository;
        private readonly IAppointmentDetailReadRepository _appointmentDetailReadRepository;
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly I_DaysMealReadRepository _daysMealReadRepository;
        private readonly I_DaysMealWriteRepository _daysMealWriteRepository;
        private readonly IExaminationReadRepository _examinationReadRepository;
        private readonly IExaminationWriteRepository _examinationWriteRepository;

        public DoctorGeneralOptionsService(
            IDaysReadRepository daysReadRepository,
            IDaysWriteRepository daysWriteRepository,
            IMealReadRepository mealReadRepository,
            IMealWriteRepository mealWriteRepository,
            IDietListReadRepository ietListReadRepository,
            IDietListWriteRepository ietListWriteRepository,
            IAppointmentDetailReadRepository appointmentDetailReadRepository,
            IMembersReadRepository membersReadRepository,
            I_DaysMealReadRepository daysMealReadRepository,
            I_DaysMealWriteRepository daysMealWriteRepository,
            IExaminationReadRepository examinationReadRepository,
            IExaminationWriteRepository examinationWriteRepository)
        {
            _daysReadRepository = daysReadRepository;
            _daysWriteRepository = daysWriteRepository;
            _mealReadRepository = mealReadRepository;
            _mealWriteRepository = mealWriteRepository;
            _ietListReadRepository = ietListReadRepository;
            _ietListWriteRepository = ietListWriteRepository;
            _appointmentDetailReadRepository = appointmentDetailReadRepository;
            _membersReadRepository = membersReadRepository;
            _daysMealReadRepository = daysMealReadRepository;
            _daysMealWriteRepository = daysMealWriteRepository;
            _examinationReadRepository = examinationReadRepository;
            _examinationWriteRepository = examinationWriteRepository;
        }


        #region Day

        public async Task<GetAllDaysQueryResponse> GetAllDaysAsync()
        {
            List<VM_Days> vM_Days = await _daysReadRepository.GetAll()
                .Select(x => new VM_Days
                {
                    Id = x.Id,
                    DayName = x.DayName
                }).ToListAsync();

            return new()
            {
                Days = vM_Days
            };
        }

        public async Task<DayCreateCommandResponse> DayCreateAsync(DayCreateCommandRequest request)
        {
            var check = await _daysReadRepository
                .GetWhere(x => x.DayName.Trim().ToLower() == request.DayName.Trim().ToLower() || x.DayName.Trim().ToUpper() == request.DayName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                Days days = new()
                {
                    DayName = request.DayName
                };

                await _daysWriteRepository.AddAsync(days);
                await _daysWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdDayQueryResponse> GetByIdDayAsync(int id)
        {
            VM_Days? vM_Days = await _daysReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Days
                {
                    Id = x.Id,
                    DayName = x.DayName
                }).FirstOrDefaultAsync();

            if (vM_Days != null)
            {
                return new()
                {
                    Day = vM_Days,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Day = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<DayUpdateCommandResponse> DayUpdateAsync(DayUpdateCommandRequest request)
        {
            Days days = await _daysReadRepository.GetByIdAsync(request.Id);

            if (days != null)
            {
                days.DayName = request.DayName;

                _daysWriteRepository.Update(days);
                await _daysWriteRepository.SaveAsync();

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

        public async Task<DayDeleteCommandResponse> DayDeleteAsync(int id)
        {
            Days days = await _daysReadRepository.GetByIdAsync(id);

            if (days != null)
            {
                _daysWriteRepository.Remove(days);
                await _daysWriteRepository.SaveAsync();

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

        #region Meal

        public async Task<GetAllMealsQueryResponse> GetAllMealsAsync()
        {
            List<VM_Meal> vM_Meals = await _mealReadRepository.GetAll()
                .Select(x => new VM_Meal
                {
                    Id = x.Id,
                    MealName = x.MealName
                }).ToListAsync();

            return new()
            {
                Meals = vM_Meals
            };
        }

        public async Task<MealCreateCommandResponse> MealCreateAsync(MealCreateCommandRequest request)
        {
            var check = await _mealReadRepository
                .GetWhere(x => x.MealName.Trim().ToLower() == request.MealName.Trim().ToLower() || x.MealName.Trim().ToUpper() == request.MealName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                Meal meal = new()
                {
                    MealName = request.MealName
                };

                await _mealWriteRepository.AddAsync(meal);
                await _mealWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdMealQueryResponse> GetByIdMealAsync(int id)
        {
            VM_Meal? vM_Meal = await _mealReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Meal
                {
                    Id = x.Id,
                    MealName = x.MealName
                }).FirstOrDefaultAsync();

            if (vM_Meal != null)
            {
                return new()
                {
                    Meal = vM_Meal,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Meal = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<MealUpdateCommandResponse> MealUpdateAsync(MealUpdateCommandRequest request)
        {
            Meal meal = await _mealReadRepository.GetByIdAsync(request.Id);

            if (meal != null)
            {
                meal.MealName = request.MealName;

                _mealWriteRepository.Update(meal);
                await _mealWriteRepository.SaveAsync();

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

        public async Task<MealDeleteCommandResponse> MealDeleteAsync(int id)
        {
            Meal meal = await _mealReadRepository.GetByIdAsync(id);
            if (meal != null)
            {
                _mealWriteRepository.Remove(meal);
                await _mealWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla gerçekleştirilmiştir.",
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

        #region DietList

        public async Task<GetDietListCreateItemsQueryResponse> GetDietListCreateItemsAsync()
        {
            List<VM_Days> vM_Days = await _daysReadRepository.GetAll()
                .Select(x => new VM_Days
                {
                    Id = x.Id,
                    DayName = x.DayName
                }).ToListAsync();

            List<VM_Meal> vM_Meals = await _mealReadRepository.GetAll()
                .Select(x => new VM_Meal
                {
                    Id = x.Id,
                    MealName = x.MealName
                }).ToListAsync();

            List<VM_AppointmentDetail> vM_AppointmentDetails = await _appointmentDetailReadRepository.GetAll()
                .Join(_membersReadRepository.GetAll(), app => app.MembersId, mem => mem.Id, (app, mem) => new { mem, app })
                .Select(x => new VM_AppointmentDetail
                {
                    Id = x.app.Id,
                    MemberName = x.mem.NameSurname,
                    Diagnosis = x.app.Diagnosis
                }).ToListAsync();

            return new()
            {
                AppointmentDetails = vM_AppointmentDetails,
                Days = vM_Days,
                Meals = vM_Meals
            };
        }

        public async Task<GetAllDietListQueryResponse> GetAllDietListAsync()
        {
            List<VM_AllDietList> vM_AllDietLists = await _ietListReadRepository.GetAll()
                .Join(_appointmentDetailReadRepository.GetAll(), di => di.AppointmentDetailId, app => app.Id, (di, app) => new { di, app })
                .Join(_daysMealReadRepository.GetAll(), die => die.di.Id, meal => meal.DietListId, (die, meal) => new { die, meal })
                .Join(_daysReadRepository.GetAll(), diet => diet.meal.DaysId, days => days.Id, (diet, days) => new { diet, days })
                .Join(_mealReadRepository.GetAll(), dietLi => dietLi.diet.meal.MealId, eal => eal.Id, (dietLi, eal) => new { dietLi, eal })
                .Join(_membersReadRepository.GetAll(), dietList => dietList.dietLi.diet.die.app.MembersId, mem => mem.Id, (dietList, mem) => new { dietList, mem })
                .Select(x => new VM_AllDietList
                {
                    Id = x.dietList.dietLi.diet.die.di.Id,
                    AppointmentDetailId = x.dietList.dietLi.diet.die.di.AppointmentDetailId,
                    DaysId = x.dietList.dietLi.diet.meal.DaysId,
                    DaysName = x.dietList.dietLi.days.DayName,
                    Description = x.dietList.dietLi.diet.die.di.Description,
                    Diagnosis = x.dietList.dietLi.diet.die.app.Diagnosis,
                    MealId = x.dietList.dietLi.diet.meal.MealId,
                    MealName = x.dietList.eal.MealName,
                    MemberName = x.mem.NameSurname,
                    TimeInterval = x.dietList.dietLi.diet.meal.TimeInterval,
                    Title = x.dietList.dietLi.diet.die.di.Title,
                    _DaysMealDescription = x.dietList.dietLi.diet.meal.Description,
                    _DaysMealId = x.dietList.dietLi.diet.meal.Id,
                    CreateDate = x.dietList.dietLi.diet.die.di.CreateDate
                }).ToListAsync();

            return new()
            {
                AllDietLists = vM_AllDietLists
            };
        }

        public async Task<DietListCreateCommandResponse> DietListCreateAsync(DietListCreateCommandRequest request)
        {
            DietList dietList = new()
            {
                AppointmentDetailId = request.AppointmentDetailId,
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId > 0 ? request.UserId : null,
                CreateDate = DateTime.Now
            };

            await _ietListWriteRepository.AddAsync(dietList);
            await _ietListWriteRepository.SaveAsync();

            _DaysMeal _DaysMeal = new()
            {
                DaysId = request.DaysId,
                Description = request._DaysDescription,
                DietListId = dietList.Id,
                MealId = request.MealId,
                TimeInterval = request.TimeInterval
            };

            await _daysMealWriteRepository.AddAsync(_DaysMeal);
            await _daysMealWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetByIdDietListQueryResponse> GetByIdDietListAsync(int id)
        {
            VM_DietList? vM_DietList = await _ietListReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_DietList
                {
                    Id = x.Id,
                    AppointmentDetailId = x.AppointmentDetailId,
                    Description = x.Description,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_DietList != null)
            {
                VM__DaysMeal? vM__DaysMeal = await _daysMealReadRepository.GetWhere(x => x.DietListId == id)
                    .Select(x => new VM__DaysMeal
                    {
                        Id = x.Id,
                        DaysId = x.DaysId,
                        Description = x.Description,
                        DietListId = x.DietListId,
                        MealId = x.MealId,
                        TimeInterval = x.TimeInterval
                    }).FirstOrDefaultAsync();                

                List<VM_Days> vM_Days = await _daysReadRepository.GetAll()
                .Select(x => new VM_Days
                {
                    Id = x.Id,
                    DayName = x.DayName
                }).ToListAsync();

                List<VM_Meal> vM_Meals = await _mealReadRepository.GetAll()
                    .Select(x => new VM_Meal
                    {
                        Id = x.Id,
                        MealName = x.MealName
                    }).ToListAsync();

                List<VM_AppointmentDetail> vM_AppointmentDetails = await _appointmentDetailReadRepository.GetAll()
                    .Join(_membersReadRepository.GetAll(), app => app.MembersId, mem => mem.Id, (app, mem) => new { mem, app })
                    .Select(x => new VM_AppointmentDetail
                    {
                        Id = x.app.Id,
                        MemberName = x.mem.NameSurname,
                        Diagnosis = x.app.Diagnosis
                    }).ToListAsync();

                return new()
                {
                    AppointmentDetails = vM_AppointmentDetails,
                    Days = vM_Days,
                    Meals = vM_Meals,
                    DaysMeal = vM__DaysMeal,
                    DietList = vM_DietList,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    AppointmentDetails = null,
                    Days = null,
                    Meals = null,
                    DaysMeal = null,
                    DietList = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<DietListUpdateCommandResponse> DietListUpdateAsync(DietListUpdateCommandRequest request)
        {
            DietList dietList = await _ietListReadRepository.GetByIdAsync(request.Id);

            if (dietList != null)
            {
                dietList.Title = request.Title;
                dietList.AppointmentDetailId = request.AppointmentDetailId;
                dietList.Description = request.Description;

                _DaysMeal? _daysMeal = await _daysMealReadRepository.GetWhere(x => x.DietListId == dietList.Id).FirstOrDefaultAsync();

                if (_daysMeal != null)
                {
                    _daysMeal.Description = request._DaysDescription;
                    _daysMeal.DaysId = request.DaysId;
                    _daysMeal.MealId = request.MealId;
                    _daysMeal.TimeInterval = request.TimeInterval;

                    _daysMealWriteRepository.Update(_daysMeal);
                    await _daysMealWriteRepository.SaveAsync();
                }
                else
                {
                    _DaysMeal _Days = new()
                    {
                        DaysId = request.DaysId,
                        MealId = request.MealId,
                        Description = request._DaysDescription,
                        DietListId = dietList.Id,
                        TimeInterval = request.TimeInterval
                    };

                    await _daysMealWriteRepository.AddAsync(_Days);
                    await _daysMealWriteRepository.SaveAsync();
                }

                _ietListWriteRepository.Update(dietList);
                await _ietListWriteRepository.SaveAsync();

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

        public async Task<DietListDeleteCommandResponse> DietListDeleteAsync(int id)
        {
            DietList dietList = await _ietListReadRepository.GetByIdAsync(id);

            if (dietList != null)
            {
                _DaysMeal? _daysMeal = await _daysMealReadRepository.GetWhere(x => x.DietListId == dietList.Id).FirstOrDefaultAsync();
                if (_daysMeal != null)
                {
                    _daysMealWriteRepository.Remove(_daysMeal);
                    await _daysMealWriteRepository.SaveAsync();
                }

                _ietListWriteRepository.Remove(dietList);
                await _ietListWriteRepository.SaveAsync();

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

        #region Examination

        public async Task<ExaminationCreateCommandResponse> ExaminationCreateAsync(ExaminationCreateCommandRequest request)
        {
            var check = await _examinationReadRepository
                .GetWhere(x => x.ExaminatioName.Trim().ToLower() == request.ExaminatioName.Trim().ToLower() || x.ExaminatioName.Trim().ToUpper() == request.ExaminatioName.Trim().ToUpper()).ToListAsync();

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
                Examination examination = new()
                {
                    ExaminatioName = request.ExaminatioName
                };

                await _examinationWriteRepository.AddAsync(examination);
                await _examinationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllExaminationQueryResponse> GetAllExaminationAsync()
        {
            List<VM_Examination> vM_Examinations = await _examinationReadRepository.GetAll()
                .Select(x=> new VM_Examination
                {
                    Id = x.Id,
                    ExaminatioName = x.ExaminatioName
                }).ToListAsync();

            return new()
            {
                Examinations = vM_Examinations
            };
        }

        public async Task<GetByIdExaminationQueryResponse> GetByIdExaminationAsync(int id)
        {
            VM_Examination? vM_Examination = await _examinationReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Examination
                {
                    Id = x.Id,
                    ExaminatioName = x.ExaminatioName
                }).FirstOrDefaultAsync();

            if (vM_Examination != null)
            {
                return new()
                {
                    Examination = vM_Examination,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Examination = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<ExaminationUpdateCommandResponse> ExaminationUpdateAsync(ExaminationUpdateCommandRequest request)
        {
            Examination examination = await _examinationReadRepository.GetByIdAsync(request.Id);

            if (examination != null)
            {
                examination.ExaminatioName = request.ExaminatioName;

                _examinationWriteRepository.Update(examination);
                await _examinationWriteRepository.SaveAsync();

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

        public async Task<ExaminationDeleteCommandResponse> ExaminationDeleteAsync(int id)
        {
            Examination examination = await _examinationReadRepository.GetByIdAsync(id);

            if (examination != null)
            {
                _examinationWriteRepository.Remove(examination);
                await _examinationWriteRepository.SaveAsync();

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
    }
}
