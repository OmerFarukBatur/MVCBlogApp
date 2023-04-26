using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetAllInfluencer;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetByIdInfluencer;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetInfluencerCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetAllOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetOurTeamCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetAllPress;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetByIdPress;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetPressCreateItems;
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

        Task<GetPressCreateItemsQueryResponse> GetPressCreateItemsAsync();
        Task<PressCreateCommandResponse> PressCreateAsync(PressCreateCommandRequest request);
        Task<GetAllPressQueryResponse> GetAllPressAsync();
        Task<GetByIdPressQueryResponse> GetByIdPressAsync(int id);
        Task<PressUpdateCommandResponse> PressUpdateAsync(PressUpdateCommandRequest request);
        Task<PressDeleteCommandResponse> PressDeleteAsync(int id);

        #endregion

        #region PressType

        Task<GetAllPressTypeQueryResponse> GetAllPressTypeAsync();
        Task<PressTypeCreateCommandResponse> PressTypeCreateAsync(PressTypeCreateCommandRequest request);
        Task<GetByIdPressTypeQueryResponse> GetByIdPressTypeAsync(int id);
        Task<PressTypeUpdateCommandResponse> PressTypeUpdateAsync(PressTypeUpdateCommandRequest request);
        Task<PressTypeDeleteCommandResponse> PressTypeDeleteAsync(int id);

        #endregion

        #region Influencer

        Task<GetInfluencerCreateItemsQueryResponse> GetInfluencerCreateItemsAsync();
        Task<GetAllInfluencerQueryResponse> GetAllInfluencerAsync();
        Task<InfluencerCreateCommandResponse> InfluencerCreateAsync(InfluencerCreateCommandRequest request);
        Task<GetByIdInfluencerQueryResponse> GetByIdInfluencerAsync(int id);
        Task<InfluencerUpdateCommandResponse> InfluencerUpdateAsync(InfluencerUpdateCommandRequest request);
        Task<InfluencerDeleteCommandResponse> InfluencerDeleteAsync(int id);

        #endregion
    }
}
