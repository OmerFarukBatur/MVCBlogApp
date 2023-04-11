using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;
using MVCBlogApp.Application.Repositories.Confession;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

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

        public UserIslemleriService(
            IMembersAuthReadRepository membersAuthReadRepository,
            IMembersReadRepository membersReadRepository,
            IMembersWriteRepository membersWriteRepository,
            IAuthService authService,
            IMailService mailService,
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IConfessionReadRepository confessionReadRepository,
            IConfessionWriteRepository confessionWriteRepository)
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
            }else 
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

        #region MemberInformation
        #endregion

        #region MemberNutritionist
        #endregion

        #region MemberAppointment
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


        #endregion
    }
}
