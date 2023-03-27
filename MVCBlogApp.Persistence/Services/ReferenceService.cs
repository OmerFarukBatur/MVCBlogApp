using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.References;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IReferencesReadRepository _referencesReadRepository;
        private readonly IReferencesWriteRepository _referencesWriteRepository;
        private readonly IStorageService _storageService;

        public ReferenceService(
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository,
            IReferencesReadRepository referencesReadRepository,
            IReferencesWriteRepository referencesWriteRepository,
            IStorageService storageService
            )
        {
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _referencesReadRepository = referencesReadRepository;
            _referencesWriteRepository = referencesWriteRepository;
            _storageService = storageService;
        }


        #region Reference

        public async Task<GetAllReferenceQueryResponse> GetAllReferenceAsync()
        {
            List<VM_References> vM_References = await _referencesReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(), rf => rf.StatusId, st => st.Id, (rf, st) => new { rf, st })
                .Select(x => new VM_References
                {
                    CreateDate = x.rf.CreateDate,
                    Id = x.rf.Id,
                    ImgUrl = x.rf.ImgUrl != null ? x.rf.ImgUrl : @"~\default-image.png",
                    StatusName = x.st.StatusName,
                    Title = x.rf.Title,
                    UrlLink = x.rf.UrlLink
                }).ToListAsync();
            return new()
            {
                References = vM_References
            };
        }

        public async Task<GetReferenceCreateItemsQueryResponse> GetReferenceCreateItemsAsync()
        {
            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                Statuses = allStatuses
            };
        }

        public async Task<ReferenceCreateCommandResponse> ReferenceCreateAsync(ReferenceCreateCommandRequest request)
        {
            var check = await _referencesReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere ait kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("reference-files", request.FormFile);

                References references = new()
                {
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreatedUserId > 0 ? request.CreatedUserId : null,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    UrlLink = request.UrlLink,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _referencesWriteRepository.AddAsync(references);
                await _referencesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

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
