﻿using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.AppointmentUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Appointment.ByIdAppointmentDateTimeUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.AppointmentDetail.AppointmentDetailUpdate;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesCreate;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesDelete;
using MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesUpdate;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAllAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetAppointmentCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetByIdAppointment;
using MVCBlogApp.Application.Features.Queries.Doctor.Appointment.GetCalenderEventList;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAllAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetAppointmentDetailCreateItems;
using MVCBlogApp.Application.Features.Queries.Doctor.AppointmentDetail.GetByIdAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Doctor.Dashboard;
using MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetAllDiseases;
using MVCBlogApp.Application.Features.Queries.Doctor.Diseases.GetByIdDiseases;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Auth;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.Diseases;
using MVCBlogApp.Application.Repositories.Event;
using MVCBlogApp.Application.Repositories.EventCategory;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

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
        private readonly IAppointmentDetailReadRepository _appointmentDetailReadRepository;
        private readonly IAppointmentDetailWriteRepository _appointmentDetailWriteRepository;
        private readonly IDiseasesReadRepository _iseasesReadRepository;
        private readonly IDiseasesWriteRepository _iseasesWriteRepository;
        private readonly IEventReadRepository _eventReadRepository;
        private readonly IEventCategoryReadRepository _eventCategoryReadRepository;

        public DoctorReportProccessService(
            ID_AppointmentReadRepository d_AppointmentReadRepository,
            ID_AppointmentWriteRepository d_AppointmentWriteRepository,
            IStatusReadRepository statusRepository,
            IUserReadRepository userReadRepository,
            IMembersReadRepository membersReadRepository,
            IAuthReadRepository authReadRepository,
            IAppointmentDetailReadRepository appointmentDetailReadRepository,
            IAppointmentDetailWriteRepository appointmentDetailWriteRepository,
            IDiseasesReadRepository iseasesReadRepository,
            IDiseasesWriteRepository iseasesWriteRepository,
            IEventReadRepository eventReadRepository,
            IEventCategoryReadRepository eventCategoryReadRepository)
        {
            _d_AppointmentReadRepository = d_AppointmentReadRepository;
            _d_AppointmentWriteRepository = d_AppointmentWriteRepository;
            _statusReadRepository = statusRepository;
            _userReadRepository = userReadRepository;
            _membersReadRepository = membersReadRepository;
            _authReadRepository = authReadRepository;
            _appointmentDetailReadRepository = appointmentDetailReadRepository;
            _appointmentDetailWriteRepository = appointmentDetailWriteRepository;
            _iseasesReadRepository = iseasesReadRepository;
            _iseasesWriteRepository = iseasesWriteRepository;
            _eventReadRepository = eventReadRepository;
            _eventCategoryReadRepository = eventCategoryReadRepository;
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

        public async Task<GetByIdAppointmentQueryResponse> GetByIdAppointmentAsync(int id)
        {
            VM_D_Appointment? vM_D_Appointment = await _d_AppointmentReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_D_Appointment
                {
                    Id = x.Id,
                    AppointmentDate = x.AppointmentDate,
                    Description = x.Description,
                    MembersId = x.MembersId,
                    Price = x.Price,
                    StatusId = x.StatusId,
                    Subject = x.Subject,
                    UserId = x.UserId
                }).FirstOrDefaultAsync();

            if (vM_D_Appointment != null)
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
                    Statuses = allStatus,
                    D_Appointment = vM_D_Appointment,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Admins = null,
                    Members = null,
                    Statuses = null,
                    D_Appointment = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<AppointmentUpdateCommandResponse> AppointmentUpdateAsync(AppointmentUpdateCommandRequest request)
        {
            D_Appointment d_Appointment = await _d_AppointmentReadRepository.GetByIdAsync(request.Id);

            if (d_Appointment != null)
            {
                DateTime AppointmentDate = request.AppointmentDate.Date.Add(request.AppointmentTime.TimeOfDay);

                d_Appointment.Price = request.Price;
                d_Appointment.Description = request.Description;
                d_Appointment.MembersId = request.MembersId;
                d_Appointment.StatusId = request.StatusId;
                d_Appointment.Subject = request.Subject;
                d_Appointment.UserId = request.UserId;
                d_Appointment.AppointmentDate = AppointmentDate;

                string? statusName = await _statusReadRepository.GetWhere(x => x.Id == request.StatusId).Select(x => x.StatusName).FirstAsync();

                if (statusName == "Aktif")
                {
                    d_Appointment.IsCompleted = false;
                }

                _d_AppointmentWriteRepository.Update(d_Appointment);
                await _d_AppointmentWriteRepository.SaveAsync();

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

        public async Task<AppointmentDeleteCommandResponse> AppointmentDeleteAsync(int id)
        {
            D_Appointment d_Appointment = await _d_AppointmentReadRepository.GetByIdAsync(id);

            if (d_Appointment != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();

                d_Appointment.IsCompleted = true;
                d_Appointment.StatusId = statusId;

                _d_AppointmentWriteRepository.Update(d_Appointment);
                await _d_AppointmentWriteRepository.SaveAsync();

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

        public async Task<GetCalenderEventListQueryResponse> GetCalenderEventListAsync()
        {
            List<VM_CalenderData> vM_D_Appointments = await _d_AppointmentReadRepository.GetWhere(x => x.IsCompleted == false && x.StatusId == 1)
                .Join(_userReadRepository.GetAll(), app => app.UserId, user => user.Id, (app, user) => new { app, user })
                .Join(_membersReadRepository.GetAll(), appi => appi.app.MembersId, mem => mem.Id, (appi, mem) => new { appi, mem })
                .Join(_statusReadRepository.GetAll(), appio => appio.appi.app.StatusId, st => st.Id, (appio, st) => new { appio, st })
                .Select(x => new VM_CalenderData
                {
                    Id = x.appio.appi.app.Id,
                    Title = x.appio.mem.NameSurname,
                    Start = x.appio.appi.app.AppointmentDate,
                    Description = x.appio.appi.user.Username,
                    End = null,
                    AllDay = false, //x.appio.appi.app.IsCompleted
                    Color = "darkorange"
                }).ToListAsync();

            return new()
            {
                D_Appointments = vM_D_Appointments
            };
        }

        public async Task<ByIdAppointmentDateTimeUpdateCommandResponse> ByIdAppointmentDateTimeUpdateAsync(ByIdAppointmentDateTimeUpdateCommandRequest request)
        {
            D_Appointment d_Appointment = await _d_AppointmentReadRepository.GetByIdAsync(request.Id);

            if (d_Appointment != null)
            {
                DateTime AppointmentDate = request.AppointmentDate.Date.Add(request.AppointmentTime.TimeOfDay);
                d_Appointment.AppointmentDate = AppointmentDate;

                _d_AppointmentWriteRepository.Update(d_Appointment);
                await _d_AppointmentWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Randevu Tarihi ve Saati Güncellenmiştir.",
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

        #region AppointmentDetail

        public async Task<GetAppointmentDetailCreateItemsQueryResponse> GetAppointmentDetailCreateItemsAsync()
        {
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

            List<VM_D_Appointment> vM_D_Appointments = await _d_AppointmentReadRepository.GetAll()
                .Select(x => new VM_D_Appointment
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    AppointmentDate = x.AppointmentDate
                }).ToListAsync();

            return new()
            {
                Admins = vM_Admins,
                Members = vM_Members,
                D_Appointments = vM_D_Appointments
            };
        }

        public async Task<GetAllAppointmentDetailQueryResponse> GetAllAppointmentDetailAsync()
        {
            List<VM_AppointmentDetail> vM_AppointmentDetails = await _appointmentDetailReadRepository.GetAll()
                .Join(_userReadRepository.GetAll(), ap => ap.UserId, user => user.Id, (ap, user) => new { ap, user })
                .Join(_membersReadRepository.GetAll(), app => app.ap.MembersId, mem => mem.Id, (app, mem) => new { app, mem })
                .Select(x => new VM_AppointmentDetail
                {
                    Id = x.app.ap.Id,
                    Size = x.app.ap.Size,
                    OilRate = x.app.ap.OilRate,
                    Weight = x.app.ap.Weight,
                    MemberName = x.mem.NameSurname,
                    UserName = x.app.user.Username,

                }).ToListAsync();

            return new()
            {
                AppointmentDetails = vM_AppointmentDetails
            };
        }

        public async Task<AppointmentDetailCreateCommandResponse> AppointmentDetailCreateAsync(AppointmentDetailCreateCommandRequest request)
        {
            AppointmentDetail appointmentDetail = new()
            {
                AppointmentId = request.AppointmentId,
                Diagnosis = request.Diagnosis,
                History = request.History,
                MembersId = request.MembersId,
                OilRate = request.OilRate,
                Size = request.Size,
                Treatment = request.Treatment,
                UserId = request.UserId,
                Weight = request.Weight
            };

            await _appointmentDetailWriteRepository.AddAsync(appointmentDetail);
            await _appointmentDetailWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetByIdAppointmentDetailQueryResponse> GetByIdAppointmentDetailQueryResponse(int id)
        {
            VM_AppointmentDetail? vM_AppointmentDetail = await _appointmentDetailReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_AppointmentDetail
                {
                    Id = x.Id,
                    AppointmentId = x.AppointmentId,
                    History = x.History,
                    MembersId = x.Id,
                    Diagnosis = x.Diagnosis,
                    OilRate = x.OilRate,
                    Size = x.Size,
                    Treatment = x.Treatment,
                    Weight = x.Weight,
                    UserId = x.UserId
                }).FirstOrDefaultAsync();

            if (vM_AppointmentDetail != null)
            {
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

                List<VM_D_Appointment> vM_D_Appointments = await _d_AppointmentReadRepository.GetAll()
                    .Select(x => new VM_D_Appointment
                    {
                        Id = x.Id,
                        Subject = x.Subject,
                        AppointmentDate = x.AppointmentDate
                    }).ToListAsync();

                return new()
                {
                    Admins = vM_Admins,
                    Members = vM_Members,
                    D_Appointments = vM_D_Appointments,
                    AppointmentDetail = vM_AppointmentDetail,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    Admins = null,
                    Members = null,
                    D_Appointments = null,
                    AppointmentDetail = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<AppointmentDetailUpdateCommandResponse> AppointmentDetailUpdateAsync(AppointmentDetailUpdateCommandRequest request)
        {
            AppointmentDetail appointmentDetail = await _appointmentDetailReadRepository.GetByIdAsync(request.Id);

            if (appointmentDetail != null)
            {
                appointmentDetail.History = request.History;
                appointmentDetail.Diagnosis = request.Diagnosis;
                appointmentDetail.Size = request.Size;
                appointmentDetail.OilRate = request.OilRate;
                appointmentDetail.Treatment = request.Treatment;
                appointmentDetail.UserId = request.UserId;
                appointmentDetail.MembersId = request.MembersId;
                appointmentDetail.AppointmentId = request.AppointmentId;
                appointmentDetail.Weight = request.Weight;

                _appointmentDetailWriteRepository.Update(appointmentDetail);
                await _appointmentDetailWriteRepository.SaveAsync();

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

        public async Task<AppointmentDetailDeleteCommandResponse> AppointmentDetailDeleteAsync(int id)
        {
            AppointmentDetail appointmentDetail = await _appointmentDetailReadRepository.GetByIdAsync(id);

            if (appointmentDetail != null)
            {
                _appointmentDetailWriteRepository.Remove(appointmentDetail);
                await _appointmentDetailWriteRepository.SaveAsync();

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

        #region Diseases

        public async Task<GetAllDiseasesQueryResponse> GetAllDiseasesAsync()
        {
            List<VM_Diseases> vM_Diseases = await _iseasesReadRepository.GetAll()
                .Select(x => new VM_Diseases
                {
                    Id = x.Id,
                    DiseasesName = x.DiseasesName,
                    Type = x.Type
                }).ToListAsync();

            return new()
            {
                Diseases = vM_Diseases
            };
        }

        public async Task<DiseasesCreateCommandResponse> DiseasesCreateAsync(DiseasesCreateCommandRequest request)
        {
            var check = await _iseasesReadRepository
                .GetWhere(x => x.DiseasesName.Trim().ToLower() == request.DiseasesName.Trim().ToLower() || x.DiseasesName.Trim().ToUpper() == request.DiseasesName.Trim().ToUpper()).ToListAsync();

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
                Diseases diseases = new()
                {
                    DiseasesName = request.DiseasesName,
                    Type = request.Type
                };

                await _iseasesWriteRepository.AddAsync(diseases);
                await _iseasesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdDiseasesQueryResponse> GetByIdDiseasesAsync(int id)
        {
            VM_Diseases? vM_Diseases = await _iseasesReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Diseases
                {
                    Id = x.Id,
                    DiseasesName = x.DiseasesName,
                    Type = x.Type
                }).FirstOrDefaultAsync();

            if (vM_Diseases != null)
            {
                return new()
                {
                    Diseases = vM_Diseases,
                    Message = null,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Diseases = null,
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<DiseasesUpdateCommandResponse> DiseasesUpdateAsync(DiseasesUpdateCommandRequest request)
        {
            Diseases diseases = await _iseasesReadRepository.GetByIdAsync(request.Id);

            if (diseases != null)
            {
                diseases.DiseasesName = request.DiseasesName;
                diseases.Type = request.Type;

                _iseasesWriteRepository.Update(diseases);
                await _iseasesWriteRepository.SaveAsync();

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

        public async Task<DiseasesDeleteCommandResponse> DiseasesDeleteAsync(int id)
        {
            Diseases diseases = await _iseasesReadRepository.GetByIdAsync(id);

            if (diseases != null)
            {
                _iseasesWriteRepository.Remove(diseases);
                await _iseasesWriteRepository.SaveAsync();

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

        #region Dashboard

        public async Task<GetDoctorDashboardItemListQueryResponse> GetDoctorDashboardItemListAsync(int id)
        {
            int statusActive = await _statusReadRepository.GetWhere(x => x.StatusName == "Aktif").Select(x => x.Id).FirstAsync();
            ////// User
            List<VM_Member> members = await _membersReadRepository.GetWhere(x => x.IsActive == true)
                .Select(x => new VM_Member
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    Email = x.Email,
                    Phone = x.Phone,
                    IsActive = x.IsActive,
                    Lacation = x.Lacation,
                    CreateDate = x.CreateDate
                }).ToListAsync();
            int allUser = members.Count();

            ////// Event
            List<VM_Event> vM_Events = await _eventReadRepository.GetWhere(x => x.StatusId == statusActive)
                .Join(_statusReadRepository.GetAll(), ev => ev.StatusId, st => st.Id, (ev, st) => new { ev, st })
                .Join(_eventCategoryReadRepository.GetAll(), eve => eve.ev.EventCategoryId, ca => ca.Id, (eve, ca) => new { eve, ca })
                .Select(x => new VM_Event
                {
                    Id = x.eve.ev.Id,
                    CreateDate = x.eve.ev.CreateDate,
                    EventCategoryName = x.ca.EventCategoryName,
                    FinishDatetime = x.eve.ev.FinishDatetime,
                    StartDatetime = x.eve.ev.StartDatetime,
                    StatusName = x.eve.st.StatusName,
                    Title = x.eve.ev.Title,
                    Description = x.eve.ev.Description
                }).ToListAsync();

            List<VM_Event> oneWeekActivities = vM_Events.Where(x => x.FinishDatetime > DateTime.Now.AddDays(-7) && x.FinishDatetime < DateTime.Now.AddDays(7)).ToList();

            /// Appointment
            List<VM_D_Appointment> allAppointment = await _d_AppointmentReadRepository
                .GetWhere(x => x.StatusId == statusActive && x.UserId == id)
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

            int activeAllAppointmentCount = allAppointment.Count();
            List<VM_D_Appointment> lastWeekAppointment = allAppointment
                .Where(x => x.AppointmentDate > DateTime.Now.AddDays(-7) && x.AppointmentDate < DateTime.Now.AddDays(7)).ToList();

            return new()
            {
                ActiveAllUserCount = allUser,
                ActiveAllAppointmentCount = activeAllAppointmentCount,
                ActiveOneWeekActivities = oneWeekActivities,
                ActiveLastWeekAppointment = lastWeekAppointment
            };

        }

        #endregion
    }
}
