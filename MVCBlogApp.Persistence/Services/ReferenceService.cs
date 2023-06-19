using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
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
using MVCBlogApp.Application.Repositories.Influencer;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Application.Repositories.OurTeam;
using MVCBlogApp.Application.Repositories.Press;
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
        private readonly INewsPaperReadRepository _ewsPaperReadRepository;
        private readonly IPressReadRepository _pressReadRepository;
        private readonly IPressWriteRepository _pressWriteRepository;
        private readonly IMasterRootReadRepository _masterRootReadRepository;
        private readonly IMasterRootWriteRepository _masterRootWriteRepository;
        private readonly IInfluencerReadRepository _influencerReadRepository;
        private readonly IInfluencerWriteRepository _influencerWriteRepository;


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
            IPressTypeWriteRepository pressTypeWriteRepository,
            INewsPaperReadRepository ewsPaperReadRepository,
            IPressReadRepository pressReadRepository,
            IPressWriteRepository pressWriteRepository,
            IMasterRootReadRepository masterRootReadRepository,
            IMasterRootWriteRepository masterRootWriteRepository,
            IInfluencerReadRepository influencerReadRepository,
            IInfluencerWriteRepository influencerWriteRepository)
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
            _ewsPaperReadRepository = ewsPaperReadRepository;
            _pressReadRepository = pressReadRepository;
            _pressWriteRepository = pressWriteRepository;
            _masterRootReadRepository = masterRootReadRepository;
            _masterRootWriteRepository = masterRootWriteRepository;
            _influencerReadRepository = influencerReadRepository;
            _influencerWriteRepository = influencerWriteRepository;
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
                    ImgUrl = @"~/Upload/" + result[0].pathOrContainerName
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
                    references.ImgUrl = @"~/Upload/" + result[0].pathOrContainerName;
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
                    ImgUrl = @"~/Upload/" + result[0].pathOrContainerName
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
                    seminarVisuals.ImgUrl = @"~/Upload/" + result[0].pathOrContainerName;
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
                    ImageUrl = @"~/Upload/" + result[0].pathOrContainerName,
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

                    ourTeam.ImageUrl = @"~/Upload/" + result[0].pathOrContainerName;
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

        public async Task<GetPressCreateItemsQueryResponse> GetPressCreateItemsAsync()
        {
            List<VM_PressType> vM_PressTypes = await _pressTypeReadRepository.GetAll()
                .Select(x => new VM_PressType
                {
                    Id = x.Id,
                    PressTypeName = x.PressTypeName
                }).ToListAsync();

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

            List<VM_NewsPaper> vM_NewsPapers = await _ewsPaperReadRepository.GetAll()
                .Select(x => new VM_NewsPaper
                {
                    Id = x.Id,
                    NewsPaperName = x.NewsPaperName
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                NewsPapers = vM_NewsPapers,
                PressTypes = vM_PressTypes,
                Statuses = allStatuses
            };

        }

        public async Task<PressCreateCommandResponse> PressCreateAsync(PressCreateCommandRequest request)
        {
            var check = await _pressReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("press-files", request.FormFile);
                Press press = new()
                {
                    Title = request.Title,
                    Description = request.Description,
                    LangId = request.LangId,
                    MetaDescription = request.MetaDescription,
                    MetaKey = request.MetaKey,
                    MetaTitle = request.MetaTitle,
                    NewsPaperId = request.NewsPaperId,
                    PressTypeId = request.PressTypeId,
                    StatusId = request.StatusId,
                    SubTitle = request.SubTitle,
                    UrlLink = request.UrlLink,
                    UrlRoot = request.UrlRoot,
                    CreateDate = DateTime.Now,
                    ImageUrl = @"~/Upload/" + result[0].pathOrContainerName
                };

                await _pressWriteRepository.AddAsync(press);
                await _pressWriteRepository.SaveAsync();

                MasterRoot masterRoot = new()
                {
                    Controller = "Press",
                    Action = "Index",
                    UrlRoot = request.UrlRoot
                };

                await _masterRootWriteRepository.AddAsync(masterRoot);
                await _masterRootWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllPressQueryResponse> GetAllPressAsync()
        {
            List<VM_Press> vM_Presses = await _pressReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), pr => pr.LangId, lg => lg.Id, (pr, lg) => new { pr, lg })
                .Join(_statusReadRepository.GetAll(), pre => pre.pr.StatusId, st => st.Id, (pre, st) => new { pre, st })
                .Join(_pressTypeReadRepository.GetAll(), pres => pres.pre.pr.PressTypeId, pt => pt.Id, (pres, pt) => new { pres, pt })
                .Join(_ewsPaperReadRepository.GetAll(), press => press.pres.pre.pr.NewsPaperId, wp => wp.Id, (press, wp) => new { press, wp })
                .Select(x => new VM_Press
                {
                    Id = x.press.pres.pre.pr.Id,
                    Language = x.press.pres.pre.lg.Language,
                    StatusName = x.press.pres.st.StatusName,
                    NewsPaperName = x.wp.NewsPaperName,
                    PressTypeName = x.press.pt.PressTypeName,
                    SubTitle = x.press.pres.pre.pr.SubTitle,
                    Title = x.press.pres.pre.pr.Title,
                    ImageUrl = x.press.pres.pre.pr.ImageUrl,
                    CreateDate = x.press.pres.pre.pr.CreateDate
                }).ToListAsync();

            return new()
            {
                Presses = vM_Presses
            };
        }

        public async Task<GetByIdPressQueryResponse> GetByIdPressAsync(int id)
        {
            VM_Press? vM_Press = await _pressReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Press
                {
                    Description = x.Description,
                    Id = x.Id,
                    LangId = x.LangId,
                    MetaDescription = x.MetaDescription,
                    MetaKey = x.MetaKey,
                    MetaTitle = x.MetaTitle,
                    NewsPaperId = x.NewsPaperId,
                    PressTypeId = x.PressTypeId,
                    StatusId = x.StatusId,
                    SubTitle = x.SubTitle,
                    Title = x.Title,
                    UrlLink = x.UrlLink,
                    UrlRoot = x.UrlRoot
                }).FirstOrDefaultAsync();

            if (vM_Press != null)
            {
                List<VM_PressType> vM_PressTypes = await _pressTypeReadRepository.GetAll()
                .Select(x => new VM_PressType
                {
                    Id = x.Id,
                    PressTypeName = x.PressTypeName
                }).ToListAsync();

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

                List<VM_NewsPaper> vM_NewsPapers = await _ewsPaperReadRepository.GetAll()
                    .Select(x => new VM_NewsPaper
                    {
                        Id = x.Id,
                        NewsPaperName = x.NewsPaperName
                    }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    NewsPapers = vM_NewsPapers,
                    PressTypes = vM_PressTypes,
                    Statuses = allStatuses,
                    Press = vM_Press,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    NewsPapers = null,
                    PressTypes = null,
                    Statuses = null,
                    Press = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }

        }

        public async Task<PressUpdateCommandResponse> PressUpdateAsync(PressUpdateCommandRequest request)
        {
            Press press = await _pressReadRepository.GetByIdAsync(request.Id);

            if (press != null)
            {
                MasterRoot? masterRoot = await _masterRootReadRepository.GetWhere(x => x.UrlRoot == press.UrlRoot).FirstOrDefaultAsync();

                if (masterRoot != null && (request.UrlRoot.Trim().ToLower() != masterRoot.UrlRoot.Trim().ToLower() && request.UrlRoot.Trim().ToUpper() != masterRoot.UrlRoot.Trim().ToUpper()))
                {
                    masterRoot.UrlRoot = request.UrlRoot;

                    _masterRootWriteRepository.Update(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }

                press.Title = request.Title;
                press.UrlRoot = request.UrlRoot;
                press.MetaTitle = request.MetaTitle;
                press.MetaKey = request.MetaKey;
                press.MetaDescription = request.MetaDescription;
                press.UrlLink = request.UrlLink;
                press.NewsPaperId = request.NewsPaperId;
                press.PressTypeId = request.PressTypeId;
                press.SubTitle = request.SubTitle;
                press.Description = request.Description;
                press.LangId = request.LangId;
                press.StatusId = request.StatusId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("press-files", request.FormFile);
                    press.ImageUrl = @"~/Upload/" + result[0].pathOrContainerName;
                }

                _pressWriteRepository.Update(press);
                await _pressWriteRepository.SaveAsync();

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
                    Message = "İşlem sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        public async Task<PressDeleteCommandResponse> PressDeleteAsync(int id)
        {
            Press press = await _pressReadRepository.GetByIdAsync(id);

            if (press != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                press.StatusId = statusId;

                _pressWriteRepository.Update(press);
                await _pressWriteRepository.SaveAsync();

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

        #region PressType

        public async Task<GetAllPressTypeQueryResponse> GetAllPressTypeAsync()
        {
            List<VM_PressType> vM_PressTypes = await _pressTypeReadRepository.GetAll()
                .Select(x => new VM_PressType
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

        public async Task<GetByIdPressTypeQueryResponse> GetByIdPressTypeAsync(int id)
        {
            VM_PressType? vM_PressType = await _pressTypeReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_PressType
                {
                    Id = x.Id,
                    PressTypeName = x.PressTypeName
                }).FirstOrDefaultAsync();

            if (vM_PressType != null)
            {
                return new()
                {
                    PressType = vM_PressType,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    PressType = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<PressTypeUpdateCommandResponse> PressTypeUpdateAsync(PressTypeUpdateCommandRequest request)
        {
            PressType pressType = await _pressTypeReadRepository.GetByIdAsync(request.Id);

            if (pressType != null)
            {
                pressType.PressTypeName = request.PressTypeName;

                _pressTypeWriteRepository.Update(pressType);
                await _pressTypeWriteRepository.SaveAsync();

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
                    Message = "Güncelleme işlemi sırasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        public async Task<PressTypeDeleteCommandResponse> PressTypeDeleteAsync(int id)
        {
            PressType pressType = await _pressTypeReadRepository.GetByIdAsync(id);

            if (pressType != null)
            {
                _pressTypeWriteRepository.Remove(pressType);
                await _pressTypeWriteRepository.SaveAsync();

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
                    Message = "Silme işlemi sırasında beklenmedik bir hata oluştu."
                };
            }
        }


        #endregion

        #region Influencer

        public async Task<GetInfluencerCreateItemsQueryResponse> GetInfluencerCreateItemsAsync()
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

        public async Task<GetAllInfluencerQueryResponse> GetAllInfluencerAsync()
        {
            List<VM_Influencer> vM_Influencers = await _influencerReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(), inf => inf.StatusId, st => st.Id, (inf, st) => new { inf, st })
                .Select(x => new VM_Influencer
                {
                    Id = x.inf.Id,
                    NameSurname = x.inf.NameSurname,
                    CompanyName = x.inf.CompanyName,
                    CompanySector = x.inf.CompanySector,
                    CreateDatetime = x.inf.CreateDatetime,
                    Email = x.inf.Email,
                    Phone = x.inf.Phone,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                Influencers = vM_Influencers
            };
        }

        public async Task<InfluencerCreateCommandResponse> InfluencerCreateAsync(InfluencerCreateCommandRequest request)
        {
            var check = await _influencerReadRepository
                .GetWhere(x => x.CompanyName.Trim().ToLower() == request.CompanyName.Trim().ToLower() || x.CompanyName.Trim().ToUpper() == request.CompanyName.Trim().ToUpper()).ToListAsync();

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
                Influencer ınfluencer = new()
                {
                    NameSurname = request.NameSurname,
                    CompanyName = request.CompanyName,
                    CompanySector = request.CompanySector,
                    Email = request.Email,
                    Message = request.Message,
                    Phone = request.Phone,
                    StatusId = request.StatusId,
                    CreateDatetime = DateTime.Now
                };

                await _influencerWriteRepository.AddAsync(ınfluencer);
                await _influencerWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdInfluencerQueryResponse> GetByIdInfluencerAsync(int id)
        {
            VM_Influencer? vM_Influencer = await _influencerReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Influencer
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    CompanySector = x.CompanySector,
                    Email = x.Email,
                    Message = x.Message,
                    Phone = x.Phone,
                    StatusId = x.StatusId,
                    NameSurname = x.NameSurname
                }).FirstOrDefaultAsync();

            if (vM_Influencer != null)
            {
                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

                return new()
                {
                    Statuses = allStatuses,
                    Influencer = vM_Influencer,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Influencer = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<InfluencerUpdateCommandResponse> InfluencerUpdateAsync(InfluencerUpdateCommandRequest request)
        {
            Influencer ınfluencer = await _influencerReadRepository.GetByIdAsync(request.Id);

            if (ınfluencer != null)
            {
                ınfluencer.NameSurname = request.NameSurname;
                ınfluencer.Phone = request.Phone;
                ınfluencer.CompanySector = request.CompanySector;
                ınfluencer.CompanyName = request.CompanyName;
                ınfluencer.Email = request.Email;
                ınfluencer.Message = request.Message;
                ınfluencer.StatusId = request.StatusId;

                _influencerWriteRepository.Update(ınfluencer);
                await _influencerWriteRepository.SaveAsync();

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
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<InfluencerDeleteCommandResponse> InfluencerDeleteAsync(int id)
        {
            Influencer ınfluencer = await _influencerReadRepository.GetByIdAsync(id);

            if (ınfluencer != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                ınfluencer.StatusId = statusId;

                _influencerWriteRepository.Update(ınfluencer);
                await _influencerWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = null
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
    }
}
