using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
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

        #endregion

        #region MemberInformation
        #endregion

        #region MemberNutritionist
        #endregion

        #region MemberAppointment
        #endregion
    }
}
