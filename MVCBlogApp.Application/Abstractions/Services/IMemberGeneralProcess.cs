using MVCBlogApp.Application.Features.Commands.Member.Confession.MemberConfessionCreate;
using MVCBlogApp.Application.Features.Commands.Member.Contact.MemberContactCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate;
using MVCBlogApp.Application.Features.Queries.Member.Confession.GetMemberConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.Member.Contact.GetMemberContactCreateItems;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberByIdAppointmentDetail;
using MVCBlogApp.Application.Features.Queries.Member.MemberInfo.GetByIdMemberInfo;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IMemberGeneralProcess
    {
        #region MemberInfo

        Task<GetByIdMemberInfoQueryResponse> GetByIdMemberAsync(int id);
        Task<MemberInfoCreateCommandResponse> MemberInfoCreateAsync(MemberInfoCreateCommandRequest request);
        Task<MemberInfoUpdateCommandResponse> MemberInfoUpdateAsync(MemberInfoUpdateCommandRequest request);

        #endregion

        #region MemberAppointment

        Task<GetByIdMemberAllAppointmentQueryResponse> GetByIdMemberAllAppointmentAsync(int id);
        Task<GetByIdMemberByIdAppointmentDetailQueryResponse> GetByIdMemberByIdAppointmentAsync(int id);

        #endregion

        #region Contact

        Task<GetMemberContactCreateItemsQueryResponse> GetMemberContactCreateItemsAsync(int id);
        Task<MemberContactCreateCommandResponse> MemberContactCreateAsync(MemberContactCreateCommandRequest request);

        #endregion

        #region Confession

        Task<GetMemberConfessionCreateItemsQueryResponse> GetMemberConfessionCreateItemsAsync(int id);
        Task<MemberConfessionCreateCommandResponse> MemberConfessionCreateAsync(MemberConfessionCreateCommandRequest request);

        #endregion
    }
}
