﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhDelete;
using MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetByIdFixBmh;
using MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems;
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
            FixBmh fixBmh = await _fixBmhReadRepository.GetByIdAsync(request.Id);

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
        #endregion

        #region FixCalorieSch
        #endregion

        #region FixFeedPyramid
        #endregion

        #region FixHeartDiseases
        #endregion

        #region FixMealSize
        #endregion

        #region FixOptimum
        #endregion

        #region FixPulse
        #endregion
    }
}
