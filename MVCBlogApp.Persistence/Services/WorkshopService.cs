using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.WorkshopCategory;
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

        public WorkshopService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IWorkshopTypeReadRepository workshopTypeReadRepository,
            IWorkshopTypeWriteRepository workshopTypeWriteRepository,
            IWorkshopCategoryReadRepository workshopCategoryReadRepository,
            IWorkshopCategoryWriteRepository workshopCategoryWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _workshopTypeReadRepository = workshopTypeReadRepository;
            _workshopTypeWriteRepository = workshopTypeWriteRepository;
            _workshopCategoryReadRepository = workshopCategoryReadRepository;
            _workshopCategoryWriteRepository = workshopCategoryWriteRepository;
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



        #endregion

        #region WorkshopEducation



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
