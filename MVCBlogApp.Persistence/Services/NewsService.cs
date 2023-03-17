using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperUpdate;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetNewsPaperCreateItems;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.NewsBulletin;
using MVCBlogApp.Application.Repositories.NewsPaper;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsBulletinReadRepository _newsBulletinReadRepository;
        private readonly INewsBulletinWriteRepository _newsBulletinWriteRepository;
        private readonly INewsPaperReadRepository _newsPaperReadRepository;
        private readonly INewsPaperWriteRepository _newsPaperWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;

        public NewsService(
            INewsBulletinReadRepository newsBulletinReadRepository,
            INewsBulletinWriteRepository newsBulletinWriteRepository,
            INewsPaperReadRepository newsPaperReadRepository,
            INewsPaperWriteRepository newsPaperWriteRepository,
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository)
        {
            _newsBulletinReadRepository = newsBulletinReadRepository;
            _newsBulletinWriteRepository = newsBulletinWriteRepository;
            _newsPaperReadRepository = newsPaperReadRepository;
            _newsPaperWriteRepository = newsPaperWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
        }


        #region NewsBulletin

        public async Task<GetNewsBulletinCreateItemQueryResponse> GetNewsBulletinCreateItemAsync()
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

        public async Task<GetAllNewsBulletinQueryResponse> GetAllNewsBulletinAsync()
        {
            List<VM_NewsBulletin> vM_NewsBulletins = await _newsBulletinReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(), nw => nw.StatusId, st => st.Id, (nw, st) => new { nw, st })
                .Select(x => new VM_NewsBulletin
                {
                    Id = x.nw.Id,
                    CreateDate = x.nw.CreateDate,
                    Email = x.nw.Email,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new() { NewsBulletins = vM_NewsBulletins };
        }

        public async Task<NewsBulletinCreateCommandResponse> NewsBulletinCreateAsync(NewsBulletinCreateCommandRequest request)
        {
            var check = await _newsBulletinReadRepository
                .GetWhere(x => x.Email.Trim().ToLower() == request.Email.Trim().ToLower() || x.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()).ToListAsync();

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
                NewsBulletin newsBulletin = new()
                {
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    Email = request.Email,
                    StatusId = request.StatusId
                };

                await _newsBulletinWriteRepository.AddAsync(newsBulletin);
                await _newsBulletinWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdNewsQueryResponse> GetByIdNewsAsync(int id)
        {
            VM_NewsBulletin? vM_NewsBulletin = await _newsBulletinReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_NewsBulletin
                {
                    Id = x.Id,
                    Email = x.Email,
                    StatusId = x.StatusId
                }).FirstOrDefaultAsync();

            if (vM_NewsBulletin != null)
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
                    NewsBulletin = vM_NewsBulletin,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    NewsBulletin = null,
                    State = false,
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }

        public async Task<NewsBulletinUpdateCommandResponse> NewsBulletinUpdateAsync(NewsBulletinUpdateCommandRequest request)
        {
            NewsBulletin newsBulletin = await _newsBulletinReadRepository.GetByIdAsync(request.Id);
            if (newsBulletin != null)
            {
                newsBulletin.Email = request.Email;
                newsBulletin.StatusId = request.StatusId;

                _newsBulletinWriteRepository.Update(newsBulletin);
                await _newsBulletinWriteRepository.SaveAsync();

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
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }

        public async Task<NewsBulletinDeleteCommandResponse> NewsBulletinDeleteAsync(int id)
        {
            NewsBulletin newsBulletin = await _newsBulletinReadRepository.GetByIdAsync(id);

            if (newsBulletin != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                newsBulletin.StatusId = statusId;

                _newsBulletinWriteRepository.Update(newsBulletin);
                await _newsBulletinWriteRepository.SaveAsync();

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
                    Message = "Bilgiye ait kayıt bulunamamıştır."
                };
            }
        }


        #endregion

        #region NewsPaper

        public async Task<GetNewsPaperCreateItemsQueryResponse> GetNewsPaperCreateItemsAsync()
        {
            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatuses
            };
        }

        public async Task<GetAllNewsPaperQueryResponse> GetAllNewsPaperAsync()
        {
            List<VM_NewsPaper> vM_NewsPapers = await _newsPaperReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), nw => nw.LangId, lg => lg.Id, (nw, lg) => new { nw, lg })
                .Join(_statusReadRepository.GetAll(), nwp => nwp.nw.StatusId, st => st.Id, (nwp, st) => new { nwp, st })
                .Select(x => new VM_NewsPaper
                {
                    Id = x.nwp.nw.Id,
                    NewsPaperName = x.nwp.nw.NewsPaperName,
                    Language = x.nwp.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                NewsPapers = vM_NewsPapers
            };
        }

        public async Task<NewsPaperCreateCommandResponse> NewsPaperCreateAsync(NewsPaperCreateCommandRequest request)
        {
            NewsPaper newsPaper = new()
            {
                LangId = request.LangId,
                NewsPaperName = request.NewsPaperName,
                StatusId = request.StatusId
            };

            await _newsPaperWriteRepository.AddAsync(newsPaper);
            await _newsPaperWriteRepository.SaveAsync();

            return new()
            {
                Message = "Kaydetme işlemi başarıyla yapılmıştır.",
                State = true
            };
        }

        public async Task<GetByIdNewsPaperQueryResponse> GetByIdNewsPaperAsync(int id)
        {
            VM_NewsPaper? newsPaper = await _newsPaperReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_NewsPaper
                {
                    Id = x.Id,
                    LangId = x.LangId,
                    NewsPaperName = x.NewsPaperName,
                    StatusId = x.StatusId
                }).FirstOrDefaultAsync();

            if (newsPaper != null)
            {
                List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

                List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                    .Select(x => new VM_Language
                    {
                        Id = x.Id,
                        Language = x.Language
                    }).ToListAsync();

                return new()
                {
                    Languages = vM_Languages,
                    NewsPaper = newsPaper,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Languages = null,
                    NewsPaper = null,
                    Statuses = null,
                    Message = "Bilgiye ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<NewsPaperUpdateCommandResponse> NewsPaperUpdateAsync(NewsPaperUpdateCommandRequest request)
        {
            NewsPaper newsPaper = await _newsPaperReadRepository.GetByIdAsync(request.Id);

            if (newsPaper != null)
            {
                newsPaper.NewsPaperName = request.NewsPaperName;
                newsPaper.StatusId = request.StatusId;
                newsPaper.LangId = request.LangId;

                _newsPaperWriteRepository.Update(newsPaper);
                await _newsPaperWriteRepository.SaveAsync();

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
                    Message = "Bilgiye ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<NewsPaperDeleteCommandResponse> NewsPaperDeleteAsync(int id)
        {
            NewsPaper newsPaper = await _newsPaperReadRepository.GetByIdAsync(id);

            if (newsPaper != null)
            {
                int statusId = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                newsPaper.StatusId = statusId;

                _newsPaperWriteRepository.Update(newsPaper);
                await _newsPaperWriteRepository.SaveAsync();

                return new()
                {
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
    }
}
