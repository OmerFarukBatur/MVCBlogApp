using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetAllWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetWorkshopEducationCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.WorkshopCategory;
using MVCBlogApp.Application.Repositories.WorkshopEducation;
using MVCBlogApp.Application.Repositories.WorkshopType;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IWorkshopTypeReadRepository _workshopTypeReadRepository;
        private readonly IWorkshopTypeWriteRepository _workshopTypeWriteRepository;
        private readonly IWorkshopCategoryReadRepository _workshopCategoryReadRepository;
        private readonly IWorkshopCategoryWriteRepository _workshopCategoryWriteRepository;
        private readonly IWorkshopEducationReadRepository _workshopEducationReadRepository;
        private readonly IWorkshopEducationWriteRepository _workshopEducationWriteRepository;

        public WorkshopService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IWorkshopTypeReadRepository workshopTypeReadRepository,
            IWorkshopTypeWriteRepository workshopTypeWriteRepository,
            IWorkshopCategoryReadRepository workshopCategoryReadRepository,
            IWorkshopCategoryWriteRepository workshopCategoryWriteRepository,
            IWorkshopEducationReadRepository workshopEducationReadRepository,
            IWorkshopEducationWriteRepository workshopEducationWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _workshopTypeReadRepository = workshopTypeReadRepository;
            _workshopTypeWriteRepository = workshopTypeWriteRepository;
            _workshopCategoryReadRepository = workshopCategoryReadRepository;
            _workshopCategoryWriteRepository = workshopCategoryWriteRepository;
            _workshopEducationReadRepository = workshopEducationReadRepository;
            _workshopEducationWriteRepository = workshopEducationWriteRepository;
        }


        #region Workshop



        #endregion

        #region WorkShopApplicationForms



        #endregion

        #region WorkshopCategory

        public async Task<GetWorkshopCategoryCreateItemsQueryResponse> GetWorkshopCategoryCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages
            };
        }

        public async Task<GetAllWorkshopCategoryQueryResponse> GetAllWorkshopCategoryAsync()
        {
            List<VM_WorkshopCategory> vM_WorkshopCategories = await _workshopCategoryReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), wk => wk.LangId, lg => lg.Id, (wk, lg) => new { wk, lg })
                .Select(x => new VM_WorkshopCategory
                {
                    Id = x.wk.Id,
                    LangId = x.wk.LangId,
                    Language = x.lg.Language,
                    WscategoryName = x.wk.WscategoryName
                }).ToListAsync();

            return new()
            {
                WorkshopCategories = vM_WorkshopCategories
            };
        }

        public async Task<WorkshopCategoryCreateCommandResponse> WorkshopCategoryCreateAsync(WorkshopCategoryCreateCommandRequest request)
        {
            var check = await _workshopCategoryReadRepository
                .GetWhere(x => x.WscategoryName.Trim().ToLower() == request.WscategoryName.Trim().ToLower() || x.WscategoryName.Trim().ToUpper() == request.WscategoryName.Trim().ToUpper()).ToListAsync();

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
                WorkshopCategory workshopCategory = new()
                {
                    WscategoryName = request.WscategoryName,
                    LangId = request.LangId
                };

                await _workshopCategoryWriteRepository.AddAsync(workshopCategory);
                await _workshopCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdWorkshopCategoryQueryResponse> GetByIdWorkshopCategoryAsync(int id)
        {
            VM_WorkshopCategory? vM_WorkshopCategory = await _workshopCategoryReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_WorkshopCategory
                {
                    Id = x.Id,
                    LangId = x.LangId,
                    WscategoryName = x.WscategoryName
                }).FirstOrDefaultAsync();

            if (vM_WorkshopCategory != null)
            {
                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    WorkshopCategory = vM_WorkshopCategory,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    WorkshopCategory = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<WorkshopCategoryUpdateCommandResponse> WorkshopCategoryUpdateAsync(WorkshopCategoryUpdateCommandRequest request)
        {
            WorkshopCategory workshopCategory = await _workshopCategoryReadRepository.GetByIdAsync(request.Id);
            if (workshopCategory != null)
            {
                workshopCategory.LangId = request.LangId;
                workshopCategory.WscategoryName = request.WscategoryName;

                _workshopCategoryWriteRepository.Update(workshopCategory);
                await _workshopCategoryWriteRepository.SaveAsync();

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

        public async Task<WorkshopCategoryDeleteCommandResponse> WorkshopCategoryDeleteAsync(int id)
        {
            WorkshopCategory workshopCategory = await _workshopCategoryReadRepository.GetByIdAsync(id);
            if (workshopCategory != null)
            {
                _workshopCategoryWriteRepository.Remove(workshopCategory);
                await _workshopCategoryWriteRepository.SaveAsync();

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
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }



        #endregion

        #region WorkshopEducation

        public async Task<GetWorkshopEducationCreateItemsQueryResponse> GetWorkshopEducationCreateItemsAsync()
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

            List<VM_WorkshopCategory> vM_WorkshopCategories = await _workshopCategoryReadRepository.GetAll()
                .Select(x => new VM_WorkshopCategory
                {
                    Id = x.Id,
                    WscategoryName = x.WscategoryName
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatuses,
                WorkshopCategories = vM_WorkshopCategories
            };
        }

        public async Task<GetAllWorkshopEducationQueryResponse> GetAllWorkshopEducationAsync()
        {
            List<VM_WorkshopEducation> vM_WorkshopEducations = await _workshopEducationReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), wo => wo.LangId, lg => lg.Id, (wo, lg) => new { wo, lg })
                .Join(_statusReadRepository.GetAll(), work => work.wo.StatusId, st => st.Id, (work, st) => new { work, st })
                .Join(_workshopCategoryReadRepository.GetAll(), workE => workE.work.wo.WscategoryId, workC => workC.Id, (workE, workC) => new { workE, workC })
                .Select(x => new VM_WorkshopEducation
                {
                    Id = x.workE.work.wo.Id,
                    WsEducationName = x.workE.work.wo.WsEducationName,
                    Language = x.workE.work.lg.Language,
                    StatusName = x.workE.st.StatusName,
                    WscategoryName = x.workC.WscategoryName
                }).ToListAsync();

            return new()
            {
                WorkshopEducations = vM_WorkshopEducations
            };
        }

        public async Task<WorkshopEducationCreateCommandResponse> WorkshopEducationCreateAsync(WorkshopEducationCreateCommandRequest request)
        {
            var check = await _workshopEducationReadRepository
                .GetWhere(x => x.WsEducationName.Trim().ToLower() == request.WsEducationName.Trim().ToLower() || x.WsEducationName.Trim().ToUpper() == request.WsEducationName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                WorkshopEducation workshopEducation = new()
                {
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    WscategoryId = request.WscategoryId,
                    WsEducationName = request.WsEducationName,
                };

                await _workshopEducationWriteRepository.AddAsync(workshopEducation);
                await _workshopEducationWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }



        #endregion

        #region WorkshopType

        public async Task<GetWorkshopTypeCreateItemsQueryResponse> GetWorkshopTypeCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages
            };
        }
        public async Task<GetAllWorkshopTypeQueryResponse> GetAllWorkshopTypeAsync()
        {
            List<VM_WorkshopType> vM_WorkshopTypes = await _workshopTypeReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), wk => wk.LangId, lg => lg.Id, (wk, lg) => new { wk, lg })
                .Select(x => new VM_WorkshopType
                {
                    Id = x.wk.Id,
                    LangId = x.wk.LangId,
                    Language = x.lg.Language,
                    WstypeName = x.wk.WstypeName
                }).ToListAsync();

            return new()
            {
                WorkshopTypes = vM_WorkshopTypes
            };
        }

        public async Task<WorkshopTypeCreateCommandResponse> WorkshopTypeCreateAsync(WorkshopTypeCreateCommandRequest request)
        {
            var check = await _workshopTypeReadRepository
                .GetWhere(x => x.WstypeName.Trim().ToLower() == request.WstypeName.Trim().ToLower() || x.WstypeName.Trim().ToUpper() == request.WstypeName.Trim().ToUpper()).ToListAsync();

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
                WorkshopType workshopType = new()
                {
                    LangId = request.LangId,
                    WstypeName = request.WstypeName,
                };

                await _workshopTypeWriteRepository.AddAsync(workshopType);
                await _workshopTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdWorkshopTypeQueryResponse> GetByIdWorkshopTypeAsync(int id)
        {
            VM_WorkshopType? vM_WorkshopType = await _workshopTypeReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_WorkshopType
                {
                    Id = x.Id,
                    LangId = x.LangId,
                    WstypeName = x.WstypeName
                }).FirstOrDefaultAsync();

            if (vM_WorkshopType != null)
            {
                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    WorkshopType = vM_WorkshopType,
                    State = true,
                    Message = null
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    WorkshopType = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }

        public async Task<WorkshopTypeUpdateCommandResponse> WorkshopTypeUpdateAsync(WorkshopTypeUpdateCommandRequest request)
        {
            WorkshopType workshopType = await _workshopTypeReadRepository.GetByIdAsync(request.Id);

            if (workshopType != null)
            {
                workshopType.WstypeName = request.WstypeName;
                workshopType.LangId = request.LangId;

                _workshopTypeWriteRepository.Update(workshopType);
                await _workshopTypeWriteRepository.SaveAsync();

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

        public async Task<WorkshopTypeDeleteCommandResponse> WorkshopTypeDeleteAsync(int id)
        {
            WorkshopType workshopType = await _workshopTypeReadRepository.GetByIdAsync(id);

            if (workshopType != null)
            {
                _workshopTypeWriteRepository.Remove(workshopType);
                await _workshopTypeWriteRepository.SaveAsync();

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
                    Message = "Kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        
        #endregion

    }
}
