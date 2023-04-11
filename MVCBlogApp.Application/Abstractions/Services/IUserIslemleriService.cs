using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IUserIslemleriService
    {
        #region Member

        Task<GetUserCreateItemsQueryResponse> GetUserCreateItemsAsync();
        Task<GetAllUserQueryResponse> GetAllUserAsync();
        Task<GetByIdUserQueryResponse> GetByIdUserAsync(int id);
        Task<UserCreateCommandResponse> UserCreateAsync(UserCreateCommandRequest request);
        Task<UserUpdateCommandResponse> UserUpdateAsync(UserUpdateCommandRequest request);
        Task<UserDeleteCommandResponse> UserDeleteAsync(int id);

        #endregion

        #region MemberInformation
        #endregion

        #region MemberNutritionist
        #endregion

        #region MemberAppointment
        #endregion

        #region Confession

        Task<GetConfessionCreateItemsQueryResponse> GetConfessionCreateItemsAsync();
        Task<GetAllConfessionQueryResponse> GetAllConfessionAsync();
        Task<ConfessionCreateCommandResponse> ConfessionCreateAsync(ConfessionCreateCommandRequest request);

        #endregion
    }
}
