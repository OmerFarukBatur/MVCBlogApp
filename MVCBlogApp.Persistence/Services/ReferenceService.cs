using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate;
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
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetAllSeminarVisuals;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetSeminarVisualsCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.OurTeam;
using MVCBlogApp.Application.Repositories.PressType;
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
        private readonly IOurTeamReadRepository _ourTeamReadRepository;
        private readonly IOurTeamWriteRepository _ourTeamWriteRepository;
        private readonly IPressTypeReadRepository _pressTypeReadRepository;
        private readonly IPressTypeWriteRepository _pressTypeWriteRepository;

        public ReferenceService(
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository,
            IReferencesReadRepository referencesReadRepository,
            IReferencesWriteRepository referencesWriteRepository,
            IStorageService storageService,
            ISeminarVisualsReadRepository seminarVisualsReadRepository,
            ISeminarVisualsWriteRepository seminarVisualsWriteRepository,
            IOurTeamReadRepository ourTeamReadRepository,
            IOurTeamWriteRepository ourTeamWriteRepository,
            IPressTypeReadRepository pressTypeReadRepository,
            IPressTypeWriteRepository pressTypeWriteRepository)
        {
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _referencesReadRepository = referencesReadRepository;
            _referencesWriteRepository = referencesWriteRepository;
            _storageService = storageService;
            _seminarVisualsReadRepository = seminarVisualsReadRepository;
            _seminarVisualsWriteRepository = seminarVisualsWriteRepository;
            _ourTeamReadRepository = ourTeamReadRepository;
            _ourTeamWriteRepository = ourTeamWriteRepository;
            _pressTypeReadRepository = pressTypeReadRepository;
            _pressTypeWriteRepository = pressTypeWriteRepository;
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

        public async Task<GetOurTeamCreateItemsQueryResponse> GetOurTeamCreateItemsAsync()
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

        public async Task<OurTeamCreateCommandResponse> OurTeamCreateAsync(OurTeamCreateCommandRequest request)
        {
            var check = await _ourTeamReadRepository
                .GetWhere(x => (x.NameSurname.Trim().ToLower() == request.NameSurname.Trim().ToLower() || x.NameSurname.Trim().ToUpper() == request.NameSurname.Trim().ToUpper()) &&
                (x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper())).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("ourteam-files", request.FormFile);

                OurTeam ourTeam = new()
                {
                    Bio = request.Bio,
                    LangId = request.LangId,
                    NameSurname = request.NameSurname,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    CreateDate = DateTime.Now,
                    ImageUrl = @"~\Upload\" + result[0].pathOrContainerName,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null
                };

                await _ourTeamWriteRepository.AddAsync(ourTeam);
                await _ourTeamWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllOurTeamCommandResponse> GetAllOurTeamAsync()
        {
            List<VM_OurTeam> vM_OurTeams = await _ourTeamReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), ou => ou.LangId, lg => lg.Id, (ou, lg) => new { ou, lg })
                .Join(_statusReadRepository.GetAll(), our => our.ou.StatusId, st => st.Id, (our, st) => new { our, st })
                .Select(x => new VM_OurTeam
                {
                    Id = x.our.ou.Id,
                    CreateDate = x.our.ou.CreateDate,
                    NameSurname = x.our.ou.NameSurname,
                    Title = x.our.ou.Title,
                    Language = x.our.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                OurTeams = vM_OurTeams
            };
        }

        public async Task<GetByIdOurTeamQueryResponse> GetByIdOurTeamAsync(int id)
        {
            VM_OurTeam? vM_OurTeam = await _ourTeamReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_OurTeam
                {
                    Id = x.Id,
                    Bio = x.Bio,
                    LangId = x.LangId,
                    NameSurname = x.NameSurname,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_OurTeam != null)
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
                    OurTeam = vM_OurTeam,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    OurTeam = null,
                    Statuses = null,
                    State = false,
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }

        public async Task<OurTeamUpdateCommandResponse> OurTeamUpdateAsync(OurTeamUpdateCommandRequest request)
        {
            OurTeam ourTeam = await _ourTeamReadRepository.GetByIdAsync(request.Id);

            if (ourTeam != null)
            {
                ourTeam.NameSurname = request.NameSurname;
                ourTeam.StatusId = request.StatusId;
                ourTeam.Title = request.Title;
                ourTeam.Bio = request.Bio;
                ourTeam.LangId = request.LangId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("ourteam-files", request.FormFile);

                    ourTeam.ImageUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _ourTeamWriteRepository.Update(ourTeam);
                await _ourTeamWriteRepository.SaveAsync();

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
                    Message = "Güncelleme işlemi sırasında beklenmedik bir hata oluştu. ",
                    State = false
                };
            }
        }

        public async Task<OurTeamDeleteCommandResponse> OurTeamDeleteAsync(int id)
        {
            OurTeam ourTeam = await _ourTeamReadRepository.GetByIdAsync(id);

            if (ourTeam != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                ourTeam.StatusId = statusId;

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
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }


        #endregion

        #region Press



        #endregion

        #region PressType

        public async Task<GetAllPressTypeQueryResponse> GetAllPressTypeAsync()
        {
            List<VM_PressType> vM_PressTypes = await _pressTypeReadRepository.GetAll()
                .Select(x=> new VM_PressType
                {
                    Id = x.Id,
                    PressTypeName = x.PressTypeName
                }).ToListAsync();

            return new()
            {
                PressTypes = vM_PressTypes
            };
        }

        public async Task<PressTypeCreateCommandResponse> PressTypeCreateAsync(PressTypeCreateCommandRequest request)
        {
            var check = await _pressTypeReadRepository
                .GetWhere(x => x.PressTypeName.Trim().ToLower() == request.PressTypeName.Trim().ToLower() || x.PressTypeName.Trim().ToUpper() == request.PressTypeName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bilgiye sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                PressType pressType = new()
                {
                    PressTypeName = request.PressTypeName
                };

                await _pressTypeWriteRepository.AddAsync(pressType);
                await _pressTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }




        #endregion
    }
}
