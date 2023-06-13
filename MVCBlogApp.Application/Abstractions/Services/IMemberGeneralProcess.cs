using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoCreate;
using MVCBlogApp.Application.Features.Commands.Member.MemberInfo.MemberInfoUpdate;
using MVCBlogApp.Application.Features.Queries.Member.MemberAppointment.GetByIdMemberAllAppointment;
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

        #endregion
    }
}
