using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetAllOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetOurTeamCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetAllPressType;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetByIdPressType;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetAllSeminarVisuals;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetSeminarVisualsCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IReferenceService
    {
        #region Reference

        Task<GetAllReferenceQueryResponse> GetAllReferenceAsync();
        Task<GetReferenceCreateItemsQueryResponse> GetReferenceCreateItemsAsync();
        Task<ReferenceCreateCommandResponse> ReferenceCreateAsync(ReferenceCreateCommandRequest request);
        Task<GetByIdReferenceQueryResponse> GetByIdReferenceAsync(int id);
        Task<ReferenceUpdateCommandResponse> ReferenceUpdateAsync(ReferenceUpdateCommandRequest request);
        Task<ReferenceDeleteCommandResponse> ReferenceDeleteAsync(int id);

        #endregion

        #region RoxyFileman



        #endregion

        #region SeminarVisuals

        Task<GetSeminarVisualsCreateItemsQueryResponse> GetSeminarVisualsCreateItemsAsync();
        Task<SeminarVisualsCreateCommandResponse> SeminarVisualsCreateAsync(SeminarVisualsCreateCommandRequest request);
        Task<GetAllSeminarVisualsQueryResponse> GetAllSeminarVisualsAsync();
        Task<GetByIdSeminarVisualQueryResponse> GetByIdSeminarVisualAsync(int id);
        Task<SeminarVisualsUpdateCommandResponse> SeminarVisualsUpdateAsync(SeminarVisualsUpdateCommandRequest request);
        Task<SeminarVisualsDeleteCommandResponse> SeminarVisualsDeleteAsync(int id);

        #endregion

        #region OurTeam

        Task<GetOurTeamCreateItemsQueryResponse> GetOurTeamCreateItemsAsync();
        Task<OurTeamCreateCommandResponse> OurTeamCreateAsync(OurTeamCreateCommandRequest request);
        Task<GetAllOurTeamCommandResponse> GetAllOurTeamAsync();
        Task<GetByIdOurTeamQueryResponse> GetByIdOurTeamAsync(int id);
        Task<OurTeamUpdateCommandResponse> OurTeamUpdateAsync(OurTeamUpdateCommandRequest request);
        Task<OurTeamDeleteCommandResponse> OurTeamDeleteAsync(int id);

        #endregion

        #region Press



        #endregion

        #region PressType

        Task<GetAllPressTypeQueryResponse> GetAllPressTypeAsync();
        Task<PressTypeCreateCommandResponse> PressTypeCreateAsync(PressTypeCreateCommandRequest request);
        Task<GetByIdPressTypeQueryResponse> GetByIdPressTypeAsync(int id);
        Task<PressTypeUpdateCommandResponse> PressTypeUpdateAsync(PressTypeUpdateCommandRequest request);
        Task<PressTypeDeleteCommandResponse> PressTypeDeleteAsync(int id);

        #endregion
    }
}
