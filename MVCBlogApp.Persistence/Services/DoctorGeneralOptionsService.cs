using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Day.DayUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetAllDays;
using MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay;
using MVCBlogApp.Application.Repositories.Days;
using MVCBlogApp.Application.Repositories.Meal;
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

        public DoctorGeneralOptionsService(
            IDaysReadRepository daysReadRepository,
            IDaysWriteRepository daysWriteRepository,
            IMealReadRepository mealReadRepository,
            IMealWriteRepository mealWriteRepository)
        {
            _daysReadRepository = daysReadRepository;
            _daysWriteRepository = daysWriteRepository;
            _mealReadRepository = mealReadRepository;
            _mealWriteRepository = mealWriteRepository;
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
                await _daysWriteRepository.SaveAsync() ;

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



        #endregion
    }
}
