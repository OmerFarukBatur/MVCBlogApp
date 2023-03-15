using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.VideoCategory;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class FileProcessService : IFileProcessService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IVideoCategoryReadRepository _videoCategoryReadRepository;
        private readonly IVideoCategoryWriteRepository _videoCategoryWriteRepository;

        public FileProcessService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IVideoCategoryReadRepository videoCategoryReadRepository,
            IVideoCategoryWriteRepository videoCategoryWriteRepository
            )
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _videoCategoryReadRepository = videoCategoryReadRepository;
            _videoCategoryWriteRepository = videoCategoryWriteRepository;
        }


        #region Image

        #endregion

        #region Video

        #endregion

        #region VideoCategory

        public async Task<GetVideoCategoryCreateItemsQueryResponse> GetVideoCategoryCreateItemsAsync()
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

        public async Task<GetAllVideoCategoryQueryResponse> GetAllVideoCategoryAsync()
        {
            List<VM_VideoCategory> vM_VideoCategories = await _videoCategoryReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), vct => vct.LangId, lg => lg.Id, (vct, lg) => new { vct, lg })
                .Join(_statusReadRepository.GetAll(), vict => vict.vct.StatusId, st => st.Id, (vict, st) => new { vict, st })
                .Select(x => new VM_VideoCategory
                {
                    Id = x.vict.vct.Id,
                    LangId = x.vict.vct.LangId,
                    Language = x.vict.lg.Language,
                    StatusId = x.vict.vct.StatusId,
                    StatusNme = x.st.StatusName,
                    VideoCategoryName = x.vict.vct.VideoCategoryName
                }).ToListAsync();

            return new()
            {
                VideoCategories = vM_VideoCategories
            };
        }

        public async Task<VideoCategoryCreateCommandResponse> VideoCategoryCreateAsync(VideoCategoryCreateCommandRequest request)
        {
            var check = await _videoCategoryReadRepository.GetWhere(x => x.VideoCategoryName.Trim().ToLower() == request.VideoCategoryName.Trim().ToLower() || x.VideoCategoryName.Trim().ToUpper() == request.VideoCategoryName.Trim().ToUpper()).ToListAsync();

            if (check.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                VideoCategory videoCategory = new()
                {
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    VideoCategoryName = request.VideoCategoryName
                };

                await _videoCategoryWriteRepository.AddAsync(videoCategory);
                await _videoCategoryWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = "Kayıt işlemi başarılı bir şekilde yapılmıştır."
                };
            }
        }

        public async Task<GetByIdVideoCategoryQueryResponse> GetByIdVideoCategoryAsync(int id)
        {
            VM_VideoCategory? vM_VideoCategory = await _videoCategoryReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_VideoCategory
                {
                    Id = x.Id,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    VideoCategoryName = x.VideoCategoryName
                }).FirstOrDefaultAsync();

            if (vM_VideoCategory != null)
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
                    State = true,
                    VideoCategory = vM_VideoCategory,
                    Languages = vM_Languages,
                    Statuses = allStatuses
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    VideoCategory = null,
                    Message = "Bilgiye ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<VideoCategoryUpdateCommandResponse> VideoCategoryUpdateAsync(VideoCategoryUpdateCommandRequest request)
        {
            VideoCategory videoCategory = await _videoCategoryReadRepository.GetByIdAsync(request.Id);
            if (videoCategory != null)
            {
                videoCategory.StatusId = request.StatusId;
                videoCategory.LangId = request.LangId;
                videoCategory.VideoCategoryName = request.VideoCategoryName;

                _videoCategoryWriteRepository.Update(videoCategory);
                await _videoCategoryWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = "Güncelleme işlemi başarılı bir şekilde yapılmıştır."
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<VideoCategoryDeleteCommandResponse> VideoCategoryDeleteAsync(int id)
        {
            VideoCategory videoCategory = await _videoCategoryReadRepository.GetByIdAsync(id);
            if (videoCategory != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();

                videoCategory.StatusId = statusId;
                _videoCategoryWriteRepository.Update(videoCategory);
                await _videoCategoryWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgiye sahip kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        #endregion

    }
}
