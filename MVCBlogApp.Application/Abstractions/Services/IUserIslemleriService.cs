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
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberNutritionist.GetAllMemberNutritionist;
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

        #region MembersInformation



        #endregion

        #region MemberNutritionist

        Task<GetAllMemberNutritionistQueryResponse> GetAllMemberNutritionistAsync();

        #endregion

        #region MemberAppointment

        Task<GetAllMemberAppointmentQueryResponse> GetAllMemberAppointmentAsync();
        Task<GetByIdAppointmentDetailQueryResponse> GetByIdAppointmentDetailAsync(int id);

        #endregion

        #region Confession

        Task<GetConfessionCreateItemsQueryResponse> GetConfessionCreateItemsAsync();
        Task<GetAllConfessionQueryResponse> GetAllConfessionAsync();
        Task<ConfessionCreateCommandResponse> ConfessionCreateAsync(ConfessionCreateCommandRequest request);
        Task<GetByIdConfessionQueryResponse> GetByIdConfessionAsync(int id);
        Task<ConfessionUpdateCommandResponse> ConfessionUpdateAsync(ConfessionUpdateCommandRequest request); 
        Task<ConfessionDeleteCommandResponse> ConfessionDeleteAsync(int id);

        #endregion

        #region ConsultancyFormType

        Task<GetAllCFTQueryResponse> GetAllCFTAsync();
        Task<CFTCreateCommandResponse> CFTCreateAsync(CFTCreateCommandRequest request);
        Task<GetByIdCFTQueryResponse> GetByIdCFTAsync(int id);
        Task<CFTUpdateCommandResponse> CFTUpdateAsync(CFTUpdateCommandRequest request);
        Task<CFTDeleteCommandResponse> CFTDeleteAsync(int id);

        #endregion

        #region ConsultancyForm

        Task<GetAllConsultancyFormQueryResponse> GetAllConsultancyFormAsync();

        #endregion
    }
}
