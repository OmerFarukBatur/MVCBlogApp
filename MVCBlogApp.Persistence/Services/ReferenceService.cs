using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
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
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.References;
using MVCBlogApp.Application.Repositories.SeminarVisuals;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStorageService _storageService;
        private readonly IReferencesReadRepository _referencesReadRepository;
        private readonly IReferencesWriteRepository _referencesWriteRepository;
        private readonly ISeminarVisualsReadRepository _seminarVisualsReadRepository;
        private readonly ISeminarVisualsWriteRepository _seminarVisualsWriteRepository;

        public ReferenceService(
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository,
            IReferencesReadRepository referencesReadRepository,
            IReferencesWriteRepository referencesWriteRepository,
            IStorageService storageService,
            ISeminarVisualsReadRepository seminarVisualsReadRepository,
            ISeminarVisualsWriteRepository seminarVisualsWriteRepository)
        {
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _referencesReadRepository = referencesReadRepository;
            _referencesWriteRepository = referencesWriteRepository;
            _storageService = storageService;
            _seminarVisualsReadRepository = seminarVisualsReadRepository;
            _seminarVisualsWriteRepository = seminarVisualsWriteRepository;
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

        public async Task<GetByIdReferenceQueryResponse> GetByIdReferenceAsync(int id)
        {
            VM_References? vM_References = await _referencesReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_References
                {
                    Id = x.Id,
                    StatusId = x.StatusId,
                    Title = x.Title,
                    UrlLink = x.UrlLink
                }).FirstOrDefaultAsync();

            if (vM_References != null)
            {
                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

                return new()
                {
                    References = vM_References,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunamamıştır.",
                    References = null,
                    State = false,
                    Statuses = null
                };
            }

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

        public async Task<ReferenceDeleteCommandResponse> ReferenceDeleteAsync(int id)
        {
            References references = await _referencesReadRepository.GetByIdAsync(id);
            if (references != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                references.StatusId = statusId;

                _referencesWriteRepository.Update(references);
                await _referencesWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Beklenmedik bir hata oluştu."
                };
            }
        }

        public async Task<ReferenceUpdateCommandResponse> ReferenceUpdateAsync(ReferenceUpdateCommandRequest request)
        {
            References references = await _referencesReadRepository.GetByIdAsync(request.Id);

            if (references != null)
            {
                references.UrlLink = request.UrlLink;
                references.Title = request.Title;
                references.StatusId = request.StatusId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("reference-files", request.FormFile);
                    references.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _referencesWriteRepository.Update(references);
                await _referencesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Güncelleme işlemi sırasında beklenmedik bir hata ile karşılaşılmıştır.",
                    State = false
                };
            }
        }

        #endregion

        #region RoxyFileman



        #endregion

        #region SeminarVisuals

        public async Task<GetSeminarVisualsCreateItemsQueryResponse> GetSeminarVisualsCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<SeminarVisualsCreateCommandResponse> SeminarVisualsCreateAsync(SeminarVisualsCreateCommandRequest request)
        {
            var check = await _seminarVisualsReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("seminarVisuals-files", request.FormFile);

                SeminarVisuals seminarVisuals = new()
                {
                    CreateDate = DateTime.Now,
                    Date = request.sCreateDate,
                    Description = request.Description,
                    LangId = request.LangId,
                    Location = request.Location,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _seminarVisualsWriteRepository.AddAsync(seminarVisuals);
                await _seminarVisualsWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllSeminarVisualsQueryResponse> GetAllSeminarVisualsAsync()
        {
            List<VM_SeminarVisuals> vM_SeminarVisuals = await _seminarVisualsReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), se => se.LangId, lg => lg.Id, (se, lg) => new { se, lg })
                .Join(_statusReadRepository.GetAll(), sem => sem.se.StatusId, st => st.Id, (sem, st) => new { sem, st })
                .Select(x => new VM_SeminarVisuals
                {
                    Id = x.sem.se.Id,
                    CreateDate = x.sem.se.CreateDate,
                    Date = x.sem.se.Date,
                    ImgUrl = x.sem.se.ImgUrl,
                    Title = x.sem.se.Title,
                    Location = x.sem.se.Location,
                    Language = x.sem.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                SeminarVisuals = vM_SeminarVisuals
            };
        }

        public async Task<GetByIdSeminarVisualQueryResponse> GetByIdSeminarVisualAsync(int id)
        {
            VM_SeminarVisuals? vM_SeminarVisuals = await _seminarVisualsReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_SeminarVisuals
                {
                    Id = x.Id,
                    Date = x.Date,
                    Description = x.Description,
                    LangId = x.LangId,
                    Location = x.Location,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_SeminarVisuals != null)
            {
                List <VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                    .Select(x => new AllStatus
                    {
                        Id = x.Id,
                        StatusName = x.StatusName
                    }).ToListAsync();

                return new()
                {
                    Statuses = allStatuses,
                    Languages = vM_Languages,
                    SeminarVisuals = vM_SeminarVisuals,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Languages = null,
                    SeminarVisuals = null,
                    State = false,
                    Message = "Bilgiye ait kayıt bulunmamaktadır."
                };
            }
        }

        public async Task<SeminarVisualsUpdateCommandResponse> SeminarVisualsUpdateAsync(SeminarVisualsUpdateCommandRequest request)
        {
            SeminarVisuals seminarVisuals = await _seminarVisualsReadRepository.GetByIdAsync(request.Id);

            if (seminarVisuals != null)
            {
                seminarVisuals.Title = request.Title;
                seminarVisuals.Location = request.Location;
                seminarVisuals.Description = request.Description;
                seminarVisuals.Date = request.sCreateDate;
                seminarVisuals.LangId = request.LangId;
                seminarVisuals.StatusId = request.StatusId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("seminarVisuals-files", request.FormFile);
                    seminarVisuals.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _seminarVisualsWriteRepository.Update(seminarVisuals);
                await _seminarVisualsWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Güncelleme işlemi sırasında beklenmedik bir hata ile karşılaşıldı.",
                    State = false
                };
            }
        }

        public async Task<SeminarVisualsDeleteCommandResponse> SeminarVisualsDeleteAsync(int id)
        {
            SeminarVisuals seminarVisuals = await _seminarVisualsReadRepository.GetByIdAsync(id);

            if (seminarVisuals != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                seminarVisuals.StatusId = statusId;

                _seminarVisualsWriteRepository.Update(seminarVisuals);
                await _seminarVisualsWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bilgiye ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion

        #region OurTeam



        #endregion

        #region Press



        #endregion

        #region PressType



        #endregion
    }
}
