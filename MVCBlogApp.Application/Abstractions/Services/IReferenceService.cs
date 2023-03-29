using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate;
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



        #endregion

        #region Press



        #endregion

        #region PressType



        #endregion
    }
}
