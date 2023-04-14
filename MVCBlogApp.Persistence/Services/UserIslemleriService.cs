using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
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
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;
using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Application.Repositories.ConsultancyForm;
using MVCBlogApp.Application.Repositories.ConsultancyFormType;
using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.User;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Persistence.Repositories.ConsultancyFormType;

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
            IAppointmentDetailReadRepository appointmentDetailReadRepository)
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
