using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;
using MVCBlogApp.Application.Repositories.Members;
using MVCBlogApp.Application.Repositories.MembersAuth;
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

        public UserIslemleriService(
            IMembersAuthReadRepository membersAuthReadRepository,
            IMembersReadRepository membersReadRepository,
            IMembersWriteRepository membersWriteRepository,
            IAuthService authService
,
            IMailService mailService)
        {
            _membersAuthReadRepository = membersAuthReadRepository;
            _membersReadRepository = membersReadRepository;
            _membersWriteRepository = membersWriteRepository;
            _authService = authService;
            _mailService = mailService;
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

        #endregion

        #region MemberInformation
        #endregion

        #region MemberNutritionist
        #endregion

        #region MemberAppointment
        #endregion

    }
}
