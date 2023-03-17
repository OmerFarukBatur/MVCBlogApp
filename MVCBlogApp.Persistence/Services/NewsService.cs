using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem;
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

        public NewsService(
            INewsBulletinReadRepository newsBulletinReadRepository, 
            INewsBulletinWriteRepository newsBulletinWriteRepository, 
            INewsPaperReadRepository newsPaperReadRepository, 
            INewsPaperWriteRepository newsPaperWriteRepository, 
            IStatusReadRepository statusReadRepository
            )
        {
            _newsBulletinReadRepository = newsBulletinReadRepository;
            _newsBulletinWriteRepository = newsBulletinWriteRepository;
            _newsPaperReadRepository = newsPaperReadRepository;
            _newsPaperWriteRepository = newsPaperWriteRepository;
            _statusReadRepository = statusReadRepository;
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



        #endregion
    }
}
