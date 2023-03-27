﻿using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageDelete;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageUpdate;
using MVCBlogApp.Application.Features.Commands.File.Image.ImageUpload;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoCreate;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoDelete;
using MVCBlogApp.Application.Features.Commands.File.Video.VideoUpdate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.File.Image.GetAllImage;
using MVCBlogApp.Application.Features.Queries.File.Image.GetByIdImage;
using MVCBlogApp.Application.Features.Queries.File.Image.GetUploadImageItems;
using MVCBlogApp.Application.Features.Queries.File.Video.GetAllVideo;
using MVCBlogApp.Application.Features.Queries.File.Video.GetByIdVideo;
using MVCBlogApp.Application.Features.Queries.File.Video.GetVideoCreateItems;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems;
using MVCBlogApp.Application.Repositories.Image;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.Video;
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
        private readonly IVideoReadRepository _videoReadRepository;
        private readonly IVideoWriteRepository _videoWriteRepository;
        private readonly IImageReadRepository _imageReadRepository;
        private readonly IImageWriteRepository _imageWriteRepository;
        private readonly IStorageService _storageService;

        public FileProcessService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IVideoCategoryReadRepository videoCategoryReadRepository,
            IVideoCategoryWriteRepository videoCategoryWriteRepository,
            IVideoReadRepository videoReadRepository,
            IVideoWriteRepository videoWriteRepository,
            IImageReadRepository imageReadRepository,
            IImageWriteRepository imageWriteRepository,
            IStorageService storageService)
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _videoCategoryReadRepository = videoCategoryReadRepository;
            _videoCategoryWriteRepository = videoCategoryWriteRepository;
            _videoReadRepository = videoReadRepository;
            _videoWriteRepository = videoWriteRepository;
            _imageReadRepository = imageReadRepository;
            _imageWriteRepository = imageWriteRepository;
            _storageService = storageService;
        }


        #region Image

        public async Task<GetUploadImageItemsQueryResponse> GetUploadImageItemsAsync()
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
                Languages = vM_Languages
            };
        }

        public async Task<ImageUploadCommandResponse> ImageUploadAsync(ImageUploadCommandRequest request)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("image-files", request.FormFile);
            Image ımage = new()
            {
                CreateDate = DateTime.Now,
                CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                ImageUrl = @"~\Upload\" + result[0].pathOrContainerName,
                IsCover = request.IsCover,
                LangId = request.LangId,
                StatusId = request.StatusId,
                Title = request.Title
            };

            await _imageWriteRepository.AddAsync(ımage);
            await _imageWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kayıt işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetAllImageQueryResponse> GetAllImageAsync()
        {
            List<VM_Image> vM_Images = await _imageReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), im => im.LangId, lg => lg.Id, (im, lg) => new { im, lg })
                .Join(_statusReadRepository.GetAll(), image => image.im.StatusId, st => st.Id, (image, st) => new { image, st })
                .Select(x => new VM_Image
                {
                    Id = x.image.im.Id,
                    CreateDate = x.image.im.CreateDate,
                    IsCover = x.image.im.IsCover,
                    Language = x.image.lg.Language,
                    StatusName = x.st.StatusName,
                    Title = x.image.im.Title
                }).ToListAsync();

            return new()
            {
                Images = vM_Images
            };
        }

        public async Task<GetByIdImageQueryResponse> GetByIdImageAsync(int id)
        {
            VM_Image? vM_Image = await _imageReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Image
                {
                    Id = x.Id,
                    IsCover = x.IsCover,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (vM_Image != null)
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
                    Image = vM_Image,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Image = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Bu bilgiye sahip kayıt bulunmamaktadır."
                };
            }

        }

        public async Task<ImageUpdateCommandResponse> ImageUpdateAsync(ImageUpdateCommandRequest request)
        {
            Image ımage = await _imageReadRepository.GetByIdAsync(request.Id);

            if (ımage != null)
            {
                ımage.Title = request.Title;
                ımage.StatusId = request.StatusId;
                ımage.IsCover = request.IsCover;
                ımage.LangId = request.LangId;

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("image-files", request.FormFile);
                    ımage.ImageUrl = @"~\Upload\" + result[0].pathOrContainerName;
                }

                _imageWriteRepository.Update(ımage);
                await _imageWriteRepository.SaveAsync();

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
                    State = false,
                    Message = "Bu bilgiye ait kayıt bulunmamaktadır."
                };
            }

        }

        public async Task<ImageDeleteCommandResponse> ImageDeleteAsync(int id)
        {
            Image ımage = await _imageReadRepository.GetByIdAsync(id);

            if (ımage != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();

                ımage.StatusId = statusId;

                _imageWriteRepository.Update(ımage);
                await _imageWriteRepository.SaveAsync();

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
                    Message = "Bu bilgiye ait kayıt bulunmamaktadır."
                };
            }
        }



        #endregion

        #region Video

        public async Task<GetVideoCreateItemsQueryResponse> GetVideoCreateItemsAsync()
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

            List<VM_VideoCategory> vM_VideoCategories = await _videoCategoryReadRepository.GetAll()
                .Select(x => new VM_VideoCategory
                {
                    Id = x.Id,
                    VideoCategoryName = x.VideoCategoryName
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatuses,
                VideoCategories = vM_VideoCategories
            };
        }

        public async Task<VideoCreateCommandResponse> VideoCreateAsync(VideoCreateCommandRequest request)
        {
            var check = await _videoReadRepository.GetWhere(v => v.Title.Trim().ToLower() == request.Title.Trim().ToLower() || v.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                Video video = new()
                {
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    Description = request.Description,
                    LangId = request.LangId,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    VideoCategoryId = request.VideoCategoryId,
                    VideoEmbedCode = request.VideoEmbedCode,
                    VideoUrl = request.VideoUrl
                };

                await _videoWriteRepository.AddAsync(video);
                await _videoWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kaydetme işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllVideoQueryResponse> GetAllVideoAsync()
        {
            List<VM_Video> vM_Videos = await _videoReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), vi => vi.LangId, lg => lg.Id, (vi, lg) => new { vi, lg })
                .Join(_statusReadRepository.GetAll(), vid => vid.vi.StatusId, st => st.Id, (vid, st) => new { vid, st })
                .Join(_videoCategoryReadRepository.GetAll(), video => video.vid.vi.VideoCategoryId, vct => vct.Id, (video, vct) => new { video, vct })
                .Select(x => new VM_Video
                {
                    Id = x.video.vid.vi.Id,
                    CreateDate = x.video.vid.vi.CreateDate,
                    Language = x.video.vid.lg.Language,
                    StatusName = x.video.st.StatusName,
                    VideoCategoryName = x.vct.VideoCategoryName,
                    Title = x.video.vid.vi.Title
                }).ToListAsync();

            return new()
            {
                Videos = vM_Videos
            };
        }

        public async Task<GetByIdVideoQueryResponse> GetByIdVideoAsync(int id)
        {
            VM_Video? vM_Video = await _videoReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Video
                {
                    Id = x.Id,
                    Description = x.Description,
                    LangId = x.LangId,
                    StatusId = x.StatusId,
                    Title = x.Title,
                    VideoCategoryId = x.VideoCategoryId,
                    VideoEmbedCode = x.VideoEmbedCode,
                    VideoUrl = x.VideoUrl
                }).FirstOrDefaultAsync();

            if (vM_Video != null)
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

                List<VM_VideoCategory> vM_VideoCategories = await _videoCategoryReadRepository.GetAll()
                    .Select(x => new VM_VideoCategory
                    {
                        Id = x.Id,
                        VideoCategoryName = x.VideoCategoryName
                    }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    VideoCategories = vM_VideoCategories,
                    Video = vM_Video,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    Statuses = null,
                    Video = null,
                    VideoCategories = null,
                    Message = "Bu bilgiye ait kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<VideoUpdateCommandResponse> VideoUpdateAsync(VideoUpdateCommandRequest request)
        {
            Video video = await _videoReadRepository.GetByIdAsync(request.Id);

            if (video != null)
            {
                video.Description = request.Description;
                video.LangId = request.LangId;
                video.StatusId = request.StatusId;
                video.VideoUrl = request.VideoUrl;
                video.Title = request.Title;
                video.VideoEmbedCode = request.VideoEmbedCode;
                video.VideoCategoryId = request.VideoCategoryId;

                _videoWriteRepository.Update(video);
                await _videoWriteRepository.SaveAsync();

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
                    State = false,
                    Message = "Bu bilgiye ait kayıt bulunamamıştır."
                };
            }
        }

        public async Task<VideoDeleteCommandResponse> VideoDeleteAsync(int id)
        {
            Video video = await _videoReadRepository.GetByIdAsync(id);

            if (video != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                video.StatusId = statusId;

                _videoWriteRepository.Update(video);
                await _videoWriteRepository.SaveAsync();

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