using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IReferenceService
    {
        #region Reference

        Task<GetAllReferenceQueryResponse> GetAllReferenceAsync();
        Task<GetReferenceCreateItemsQueryResponse> GetReferenceCreateItemsAsync();
        Task<ReferenceCreateCommandResponse> ReferenceCreateAsync(ReferenceCreateCommandRequest request);

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
