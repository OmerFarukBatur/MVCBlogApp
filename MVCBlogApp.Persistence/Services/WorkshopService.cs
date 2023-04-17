using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
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

        public WorkshopService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IWorkshopTypeReadRepository workshopTypeReadRepository,
            IWorkshopTypeWriteRepository workshopTypeWriteRepository)
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _workshopTypeReadRepository = workshopTypeReadRepository;
            _workshopTypeWriteRepository = workshopTypeWriteRepository;
        }


        #region Workshop



        #endregion

        #region WorkShopApplicationForms



        #endregion

        #region WorkshopCategory



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
