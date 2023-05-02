using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentCreate;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.GetAppointmentCreateItems;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Persistence.Repositories.Status;

namespace MVCBlogApp.Persistence.Services
{
    public class DoctorReportProccessService : IDoctorReportProccessService
    {
        private readonly ID_AppointmentReadRepository _d_AppointmentReadRepository;
        private readonly ID_AppointmentWriteRepository _d_AppointmentWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMembersReadRepository _membersReadRepository;
        private readonly IAuthReadRepository _authReadRepository;

        public DoctorReportProccessService(
            ID_AppointmentReadRepository d_AppointmentReadRepository,
            ID_AppointmentWriteRepository d_AppointmentWriteRepository,
            IStatusReadRepository statusRepository,
            IUserReadRepository userReadRepository,
            IMembersReadRepository membersReadRepository,
            IAuthReadRepository authReadRepository)
        {
            _d_AppointmentReadRepository = d_AppointmentReadRepository;
            _d_AppointmentWriteRepository = d_AppointmentWriteRepository;
            _statusReadRepository = statusRepository;
            _userReadRepository = userReadRepository;
            _membersReadRepository = membersReadRepository;
            _authReadRepository = authReadRepository;
        }

        
        #region Appointment

        public async Task<GetAppointmentCreateItemsQueryResponse> GetAppointmentCreateItemsAsync()
        {
            List<AllStatus> allStatus = await _statusReadRepository
                .GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            List<VM_Admin> vM_Admins = await _userReadRepository.GetAll()
                .Join(_authReadRepository.GetAll(), us => us.AuthId, au => au.Id, (us, au) => new { us, au })
                .Select(x => new VM_Admin
                {
                    Id = x.us.Id,
                    AuthName = x.au.AuthName,
                    Username = x.us.Username
                }).ToListAsync();

            List<VM_Member> vM_Members = await _membersReadRepository.GetWhere(x => x.IsActive == true)
                .Select(x => new VM_Member
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname
                }).ToListAsync();

            return new()
            {
                Admins = vM_Admins,
                Members = vM_Members,
                Statuses = allStatus
            };

        }

        public async Task<GetAllAppointmentQueryResponse> GetAllAppointmentAsync()
        {
            List<VM_D_Appointment> vM_D_Appointments = await _d_AppointmentReadRepository.GetAll()
                .Join(_userReadRepository.GetAll(), app => app.UserId, user => user.Id, (app, user) => new { app, user })
                .Join(_membersReadRepository.GetAll(), appi => appi.app.MembersId, mem => mem.Id, (appi, mem) => new { appi, mem })
                .Join(_statusReadRepository.GetAll(), appio => appio.appi.app.StatusId, st => st.Id, (appio, st) => new { appio, st })
                .Select(x => new VM_D_Appointment
                {
                    Id = x.appio.appi.app.Id,
                    Price = x.appio.appi.app.Price,
                    MemeberName = x.appio.mem.NameSurname,
                    AppointmentDate = x.appio.appi.app.AppointmentDate,
                    StatusName = x.st.StatusName,
                    UserName = x.appio.appi.user.Username,
                    CreateDate = x.appio.appi.app.CreateDate
                }).ToListAsync();

            return new()
            {
                D_Appointments = vM_D_Appointments
            };
        }

        public async Task<AppointmentCreateCommandResponse> AppointmentCreateAsync(AppointmentCreateCommandRequest request)
        {
            DateTime AppointmentDate = request.AppointmentDate.Date.Add(request.AppointmentTime.TimeOfDay);

            var check = await _d_AppointmentReadRepository
                .GetWhere(x => x.AppointmentDate == AppointmentDate && x.MembersId == request.MembersId).ToListAsync();

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
                D_Appointment d_Appointment = new()
                {
                    AppointmentDate = AppointmentDate,
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    Description = request.Description,
                    IsCompleted = false,
                    MembersId = request.MembersId,
                    Price = request.Price,
                    StatusId = request.StatusId,
                    Subject = request.Subject,
                    UserId = request.UserId
                };

                await _d_AppointmentWriteRepository.AddAsync(d_Appointment);
                await _d_AppointmentWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }




        #endregion
    }
}
