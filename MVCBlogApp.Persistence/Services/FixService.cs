using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMICreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixFeedPyramid.FixFeedPyramidUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesUpdate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeUpdate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetByIdFixBMI;
using MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetFixBMICreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetAllFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetByIdFixCalorieSch;
using MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetFixCalorieSchCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetAllFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetByIdFixFeedPyramid;
using MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetFixFeedPyramidCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetAllFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetByIdFixHeartDiseases;
using MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetFixHeartDiseasesCreateItems;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetAllFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetByIdFixMealSize;
using MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetFixMealSizeCreateItems;
using MVCBlogApp.Application.Repositories.FixBmh;
using MVCBlogApp.Application.Repositories.FixBMI;
using MVCBlogApp.Application.Repositories.FixCalorieSch;
using MVCBlogApp.Application.Repositories.FixFeedPyramid;
using MVCBlogApp.Application.Repositories.FixHeartDiseases;
using MVCBlogApp.Application.Repositories.FixMealSize;
using MVCBlogApp.Application.Repositories.FixOptimum;
using MVCBlogApp.Application.Repositories.FixPulse;
using MVCBlogApp.Application.Repositories.Form;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class FixService : IFixService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IStorageService _storageService;
        private readonly IFormReadRepository _formReadRepository;
        private readonly IFixBmhReadRepository _fixBmhReadRepository;
        private readonly IFixBmhWriteRepository _fixBmhWriteRepository;
        private readonly IFixBMIReadRepository _fixBMIReadRepository;
        private readonly IFixBMIWriteRepository _fixBMIWriteRepository;
        private readonly IFixCalorieSchReadRepository _fixCalorieSchReadRepository;
        private readonly IFixCalorieSchWriteRepository _fixCalorieSchWriteRepository;
        private readonly IFixFeedPyramidReadRepository _fixFeedPyramidReadRepository;
        private readonly IFixFeedPyramidWriteRepository _fixFeedPyramidWriteRepository;
        private readonly IFixHeartDiseasesReadRepository _fixHeartDiseasesReadRepository;
        private readonly IFixHeartDiseasesWriteRepository _fixHeartDiseasesWriteRepository;
        private readonly IFixMealSizeReadRepository _fixMealSizeReadRepository;
        private readonly IFixMealSizeWriteRepository _fixMealSizeWriteRepository;
        private readonly IFixOptimumReadRepository _fixOptimumReadRepository;
        private readonly IFixOptimumWriteRepository _fixOptimumWriteRepository;
        private readonly IFixPulseReadRepository _fixPulseReadRepository;
        private readonly IFixPulseWriteRepository _fixPulseWriteRepository;

        public FixService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IStorageService storageService,
            IFixBmhReadRepository fixBmhReadRepository,
            IFixBmhWriteRepository fixBmhWriteRepository,
            IFixBMIReadRepository fixBMIReadRepository,
            IFixBMIWriteRepository fixBMIWriteRepository,
            IFixCalorieSchReadRepository fixCalorieSchReadRepository,
            IFixCalorieSchWriteRepository fixCalorieSchWriteRepository,
            IFixFeedPyramidReadRepository fixFeedPyramidReadRepository,
            IFixFeedPyramidWriteRepository fixFeedPyramidWriteRepository,
            IFixHeartDiseasesReadRepository fixHeartDiseasesReadRepository,
            IFixHeartDiseasesWriteRepository fixHeartDiseasesWriteRepository,
            IFixMealSizeReadRepository fixMealSizeReadRepository,
            IFixMealSizeWriteRepository fixMealSizeWriteRepository,
            IFixOptimumReadRepository fixOptimumReadRepository,
            IFixOptimumWriteRepository fixOptimumWriteRepository,
            IFixPulseReadRepository fixPulseReadRepository,
            IFixPulseWriteRepository fixPulseWriteRepository,
            IFormReadRepository formReadRepository
            )
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _storageService = storageService;
            _fixBmhReadRepository = fixBmhReadRepository;
            _fixBmhWriteRepository = fixBmhWriteRepository;
            _fixBMIReadRepository = fixBMIReadRepository;
            _fixBMIWriteRepository = fixBMIWriteRepository;
            _fixCalorieSchReadRepository = fixCalorieSchReadRepository;
            _fixCalorieSchWriteRepository = fixCalorieSchWriteRepository;
            _fixFeedPyramidReadRepository = fixFeedPyramidReadRepository;
            _fixFeedPyramidWriteRepository = fixFeedPyramidWriteRepository;
            _fixHeartDiseasesReadRepository = fixHeartDiseasesReadRepository;
            _fixHeartDiseasesWriteRepository = fixHeartDiseasesWriteRepository;
            _fixMealSizeReadRepository = fixMealSizeReadRepository;
            _fixMealSizeWriteRepository = fixMealSizeWriteRepository;
            _fixOptimumReadRepository = fixOptimumReadRepository;
            _fixOptimumWriteRepository = fixOptimumWriteRepository;
            _fixPulseReadRepository = fixPulseReadRepository;
            _fixPulseWriteRepository = fixPulseWriteRepository;
            _formReadRepository = formReadRepository;
        }


        #region FixBmh

        public async Task<GetFixBmhCreateItemsQueryResponse> GetFixBmhCreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixBmhsQueryResponse> GetAllFixBmhsAsync()
        {
            List<VM_FixBmh> vM_FixBmhs = await _fixBmhReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixBmh
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixBmhs = vM_FixBmhs,
            };
        }

        public async Task<FixBmhCreateCommandResponse> FixBmhCreateAsync(FixBmhCreateCommandRequest request)
        {
            var check = await _fixBmhReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixBmh-files", request.FormFile);

                FixBmh fixBmh = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixBmhWriteRepository.AddAsync(fixBmh);
                await _fixBmhWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixBmhQueryResponse> GetByIdFixBmhAsync(int id)
        {
            VM_FixBmh? vM_FixBmh = await _fixBmhReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixBmh
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixBmh != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixBmh = vM_FixBmh,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixBmh = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixBmhUpdateCommandResponse> FixBmhUpdateAsync(FixBmhUpdateCommandRequest request)
        {
            FixBmh fixBmh = await _fixBmhReadRepository.GetByIdAsync(request.Id);

            if (fixBmh != null)
            {
                fixBmh.Description = request.Description;
                fixBmh.Title = request.Title;
                fixBmh.StatusId = request.StatusId;
                fixBmh.LangId = request.LangId;
                fixBmh.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixBmh-files", request.FormFile);
                    fixBmh.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixBmhWriteRepository.Update(fixBmh);
                await _fixBmhWriteRepository.SaveAsync();

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

        public async Task<FixBmhDeleteCommandResponse> FixBmhDeleteAsync(int id)
        {
            FixBmh fixBmh = await _fixBmhReadRepository.GetByIdAsync(id);

            if (fixBmh != null)
            {
                _fixBmhWriteRepository.Remove(fixBmh);
                await _fixBmhWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixBMI

        public async Task<GetFixBMICreateItemsQueryResponse> GetFixBMICreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixBMIQueryResponse> GetAllFixBMIAsync()
        {
            List<VM_FixBMI> vM_FixBMIs = await _fixBMIReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixBMI
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixBMIs = vM_FixBMIs
            };
        }

        public async Task<FixBMICreateCommandResponse> FixBMICreateAsync(FixBMICreateCommandRequest request)
        {
            var check = await _fixBMIReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixBMI-files", request.FormFile);

                FixBMI fixBMI = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixBMIWriteRepository.AddAsync(fixBMI);
                await _fixBMIWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixBMIQueryResponse> GetByIdFixBMIAsync(int id)
        {
            VM_FixBMI? vM_FixBMI = await _fixBMIReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixBMI
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixBMI != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixBMI = vM_FixBMI,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixBMI = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixBMIUpdateCommandResponse> FixBMIUpdateAsync(FixBMIUpdateCommandRequest request)
        {
            FixBMI fixBMI = await _fixBMIReadRepository.GetByIdAsync(request.Id);

            if (fixBMI != null)
            {
                fixBMI.Description = request.Description;
                fixBMI.Title = request.Title;
                fixBMI.StatusId = request.StatusId;
                fixBMI.LangId = request.LangId;
                fixBMI.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixBMI-files", request.FormFile);
                    fixBMI.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixBMIWriteRepository.Update(fixBMI);
                await _fixBMIWriteRepository.SaveAsync();

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

        public async Task<FixBMIDeleteCommandResponse> FixBMIDeleteAsync(int id)
        {
            FixBMI fixBMI = await _fixBMIReadRepository.GetByIdAsync(id);

            if (fixBMI != null)
            {
                _fixBMIWriteRepository.Remove(fixBMI);
                await _fixBMIWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixCalorieSch

        public async Task<GetFixCalorieSchCreateItemsQueryResponse> GetFixCalorieSchCreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixCalorieSchQueryResponse> GetAllFixCalorieSchAsync()
        {
            List<VM_FixCalorieSch> vM_FixCalorieSches = await _fixCalorieSchReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixCalorieSch
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixCalorieSches = vM_FixCalorieSches
            };
        }

        public async Task<FixCalorieSchCreateCommandResponse> FixCalorieSchCreateAsync(FixCalorieSchCreateCommandRequest request)
        {
            var check = await _fixCalorieSchReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixCalorieSch-files", request.FormFile);

                FixCalorieSch fixCalorieSch = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixCalorieSchWriteRepository.AddAsync(fixCalorieSch);
                await _fixCalorieSchWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixCalorieSchQueryResponse> GetByIdFixCalorieSchAsync(int id)
        {
            VM_FixCalorieSch? vM_FixCalorieSch = await _fixCalorieSchReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixCalorieSch
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixCalorieSch != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixCalorieSch = vM_FixCalorieSch,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixCalorieSch = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixCalorieSchUpdateCommandResponse> FixCalorieSchUpdateAsync(FixCalorieSchUpdateCommandRequest request)
        {
            FixCalorieSch fixCalorieSch = await _fixCalorieSchReadRepository.GetByIdAsync(request.Id);

            if (fixCalorieSch != null)
            {
                fixCalorieSch.Description = request.Description;
                fixCalorieSch.Title = request.Title;
                fixCalorieSch.StatusId = request.StatusId;
                fixCalorieSch.LangId = request.LangId;
                fixCalorieSch.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixBMI-files", request.FormFile);
                    fixCalorieSch.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixCalorieSchWriteRepository.Update(fixCalorieSch);
                await _fixCalorieSchWriteRepository.SaveAsync();

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

        public async Task<FixCalorieSchDeleteCommandResponse> FixCalorieSchDeleteAsync(int id)
        {
            FixCalorieSch fixCalorieSch = await _fixCalorieSchReadRepository.GetByIdAsync(id);

            if (fixCalorieSch != null)
            {
                _fixCalorieSchWriteRepository.Remove(fixCalorieSch);
                await _fixCalorieSchWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixFeedPyramid
        public async Task<GetFixFeedPyramidCreateItemsQueryResponse> GetFixFeedPyramidCreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixFeedPyramidQueryResponse> GetAllFixFeedPyramidAsync()
        {
            List<VM_FixFeedPyramid> vM_FixFeedPyramids = await _fixFeedPyramidReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixFeedPyramid
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixFeedPyramids = vM_FixFeedPyramids,
            };
        }

        public async Task<FixFeedPyramidCreateCommandResponse> FixFeedPyramidCreateAsync(FixFeedPyramidCreateCommandRequest request)
        {
            var check = await _fixFeedPyramidReadRepository
               .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixFeedPyramid-files", request.FormFile);

                FixFeedPyramid fixFeedPyramid = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixFeedPyramidWriteRepository.AddAsync(fixFeedPyramid);
                await _fixFeedPyramidWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixFeedPyramidQueryResponse> GetByIdFixFeedPyramidAsync(int id)
        {
            VM_FixFeedPyramid? vM_FixFeedPyramid = await _fixFeedPyramidReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixFeedPyramid
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixFeedPyramid != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixFeedPyramid = vM_FixFeedPyramid,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixFeedPyramid = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixFeedPyramidUpdateCommandResponse> FixFeedPyramidUpdateAsync(FixFeedPyramidUpdateCommandRequest request)
        {
            FixFeedPyramid fixFeedPyramid = await _fixFeedPyramidReadRepository.GetByIdAsync(request.Id);

            if (fixFeedPyramid != null)
            {
                fixFeedPyramid.Description = request.Description;
                fixFeedPyramid.Title = request.Title;
                fixFeedPyramid.StatusId = request.StatusId;
                fixFeedPyramid.LangId = request.LangId;
                fixFeedPyramid.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixFeedPyramid-files", request.FormFile);
                    fixFeedPyramid.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixFeedPyramidWriteRepository.Update(fixFeedPyramid);
                await _fixFeedPyramidWriteRepository.SaveAsync();

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

        public async Task<FixFeedPyramidDeleteCommandResponse> FixFeedPyramidDeleteAsync(int id)
        {
            FixFeedPyramid fixFeedPyramid = await _fixFeedPyramidReadRepository.GetByIdAsync(id);

            if (fixFeedPyramid != null)
            {
                _fixFeedPyramidWriteRepository.Remove(fixFeedPyramid);
                await _fixFeedPyramidWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixHeartDiseases

        public async Task<GetFixHeartDiseasesCreateItemsQueryResponse> GetFixHeartDiseasesCreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixHeartDiseasesQueryResponse> GetAllFixHeartDiseasesAsync()
        {
            List<VM_FixHeartDiseases> vM_FixHeartDiseases = await _fixHeartDiseasesReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixHeartDiseases
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixHeartDiseases = vM_FixHeartDiseases,
            };
        }

        public async Task<FixHeartDiseasesCreateCommandResponse> FixHeartDiseasesCreateAsync(FixHeartDiseasesCreateCommandRequest request)
        {
            var check = await _fixHeartDiseasesReadRepository
               .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixHeartDiseases-files", request.FormFile);

                FixHeartDiseases fixHeartDiseases = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixHeartDiseasesWriteRepository.AddAsync(fixHeartDiseases);
                await _fixHeartDiseasesWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixHeartDiseasesQueryResponse> GetByIdFixHeartDiseasesAsync(int id)
        {
            VM_FixHeartDiseases? vM_FixHeartDiseases = await _fixHeartDiseasesReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixHeartDiseases
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixHeartDiseases != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixHeartDiseases = vM_FixHeartDiseases,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixHeartDiseases = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixHeartDiseasesUpdateCommandResponse> FixHeartDiseasesUpdateAsync(FixHeartDiseasesUpdateCommandRequest request)
        {
            FixHeartDiseases fixHeartDiseases = await _fixHeartDiseasesReadRepository.GetByIdAsync(request.Id);

            if (fixHeartDiseases != null)
            {
                fixHeartDiseases.Description = request.Description;
                fixHeartDiseases.Title = request.Title;
                fixHeartDiseases.StatusId = request.StatusId;
                fixHeartDiseases.LangId = request.LangId;
                fixHeartDiseases.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixHeartDiseases-files", request.FormFile);
                    fixHeartDiseases.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixHeartDiseasesWriteRepository.Update(fixHeartDiseases);
                await _fixHeartDiseasesWriteRepository.SaveAsync();

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

        public async Task<FixHeartDiseasesDeleteCommandResponse> FixHeartDiseasesDeleteAsync(int id)
        {
            FixHeartDiseases fixHeartDiseases = await _fixHeartDiseasesReadRepository.GetByIdAsync(id);

            if (fixHeartDiseases != null)
            {
                _fixHeartDiseasesWriteRepository.Remove(fixHeartDiseases);
                await _fixHeartDiseasesWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixMealSize

        public async Task<GetFixMealSizeCreateItemsQueryResponse> GetFixMealSizeCreateItemsAsync()
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

            List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                .Select(x => new VM_Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                }).ToListAsync();

            return new()
            {
                Forms = vM_Forms,
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllFixMealSizeQueryResponse> GetAllFixMealSizeAsync()
        {
            List<VM_FixMealSize> vM_FixMealSizes = await _fixMealSizeReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), f => f.LangId, lg => lg.Id, (f, lg) => new { f, lg })
                .Join(_statusReadRepository.GetAll(), fi => fi.f.StatusId, st => st.Id, (fi, st) => new { fi, st })
                .Join(_formReadRepository.GetAll(), fix => fix.fi.f.FormId, fI => fI.Id, (fix, fI) => new { fix, fI })
                .Select(x => new VM_FixMealSize
                {
                    Id = x.fix.fi.f.Id,
                    Title = x.fix.fi.f.Title,
                    FormName = x.fI.FormName,
                    Language = x.fix.fi.lg.Language,
                    StatusName = x.fix.st.StatusName
                }).ToListAsync();

            return new()
            {
                FixMealSizes = vM_FixMealSizes,
            };
        }

        public async Task<FixMealSizeCreateCommandResponse> FixMealSizeCreateAsync(FixMealSizeCreateCommandRequest request)
        {
            var check = await _fixMealSizeReadRepository
               .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixMealSize-files", request.FormFile);

                FixMealSize fixMealSize = new()
                {
                    Description = request.Description,
                    FormId = request.FormId,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    ImgUrl = @"~\Upload\" + result[0].pathOrContainerName
                };

                await _fixMealSizeWriteRepository.AddAsync(fixMealSize);
                await _fixMealSizeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdFixMealSizeQueryResponse> GetByIdFixMealSizeAsync(int id)
        {
            VM_FixMealSize? vM_FixMealSize = await _fixMealSizeReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_FixMealSize
                {
                    Id = x.Id,
                    Description = x.Description,
                    FormId = x.FormId,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_FixMealSize != null)
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

                List<VM_Form> vM_Forms = await _formReadRepository.GetAll()
                    .Select(x => new VM_Form
                    {
                        Id = x.Id,
                        FormName = x.FormName
                    }).ToListAsync();

                return new()
                {
                    FixMealSize = vM_FixMealSize,
                    Forms = vM_Forms,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    FixMealSize = null,
                    Forms = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<FixMealSizeUpdateCommandResponse> FixMealSizeUpdateAsync(FixMealSizeUpdateCommandRequest request)
        {
            FixMealSize fixMealSize = await _fixMealSizeReadRepository.GetByIdAsync(request.Id);

            if (fixMealSize != null)
            {
                fixMealSize.Description = request.Description;
                fixMealSize.Title = request.Title;
                fixMealSize.StatusId = request.StatusId;
                fixMealSize.LangId = request.LangId;
                fixMealSize.FormId = request.FormId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("fixMealSize-files", request.FormFile);
                    fixMealSize.ImgUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _fixMealSizeWriteRepository.Update(fixMealSize);
                await _fixMealSizeWriteRepository.SaveAsync();

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

        public async Task<FixMealSizeDeleteCommandResponse> FixMealSizeDeleteAsync(int id)
        {
            FixMealSize fixMealSize = await _fixMealSizeReadRepository.GetByIdAsync(id);

            if (fixMealSize != null)
            {
                _fixMealSizeWriteRepository.Remove(fixMealSize);
                await _fixMealSizeWriteRepository.SaveAsync();

                return new()
                {
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


        #endregion

        #region FixOptimum
        #endregion

        #region FixPulse
        #endregion
    }
}
