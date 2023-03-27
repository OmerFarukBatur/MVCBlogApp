using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;

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



        #endregion

        #region WorkShopApplicationForms



        #endregion

        #region Workshop



        #endregion
    }
}
