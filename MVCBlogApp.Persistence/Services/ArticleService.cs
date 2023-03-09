using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory;
using MVCBlogApp.Application.Repositories.ArticleCategory;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IArticleCategoryReadRepository _articleCategoryReadRepository;
        private readonly IArticleCategoryWriteRepository _articleCategoryWriteRepository;

        public ArticleService(
            ILanguagesReadRepository languagesReadRepository, 
            IStatusReadRepository statusReadRepository, 
            IArticleCategoryReadRepository articleCategoryReadRepository, 
            IArticleCategoryWriteRepository articleCategoryWriteRepository
            )
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _articleCategoryReadRepository = articleCategoryReadRepository;
            _articleCategoryWriteRepository = articleCategoryWriteRepository;
        }

        
        #region Article
        #endregion

        #region ArticleCategory

        public async Task<GetArticleCategoryCreateItemsQueryResponse> GetArticleCategoryCreateItemsAsync()
        {
            List<VM_ArticleCategory> vM_ArticleCategories = await _articleCategoryReadRepository.GetAll()
                .Select(x => new VM_ArticleCategory
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    Language = x.Language
                }).ToListAsync();

            List<AllStatus> allStatuses = await _statusReadRepository.GetAll()
                .Select(x=> new AllStatus 
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            return new()
            {
                ArticleCategories = vM_ArticleCategories,
                Languages = vM_Languages,
                Statuses = allStatuses
            };

        }

        public async Task<GetAllArticleCategoryQueryResponse> GetAllArticleCategoryAsync()
        {
            List<VM_ArticleCategory> vM_ArticleCategories = await _articleCategoryReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), art => art.LangId, lg => lg.Id, (art, lg) => new { art, lg })
                .Join(_statusReadRepository.GetAll(), artic => artic.art.StatusId, st => st.Id, (artic, st) => new { artic, st })
                .Select(x => new VM_ArticleCategory
                {
                    Id = x.artic.art.Id,
                    CategoryName = x.artic.art.CategoryName,
                    CreateDate = x.artic.art.CreateDate,
                    Language = x.artic.lg.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                ArticleCategories = vM_ArticleCategories
            };
        }

        public async Task<ArticleCategoryCreateCommandResponse> ArticleCategoryCreateAsync(ArticleCategoryCreateCommandRequest request)
        {
            var articleCategoryCheck = await _articleCategoryReadRepository
                .GetWhere(x => x.CategoryName.Trim().ToLower() == request.CategoryName.Trim().ToLower() || x.CategoryName.Trim().ToUpper() == request.CategoryName.Trim().ToUpper())
                .ToListAsync();

            if (articleCategoryCheck.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                ArticleCategory articleCategory = new()
                {
                    CategoryName = request.CategoryName,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    LangId = request.LangId,
                    MetaKey = request.MetaKey,
                    MetaDescription = request.MetaDescription,
                    ParentId = request.ParentId > 0 ? request.ParentId : null,
                    MetaTitle = request.MetaTitle,
                    StatusId = request.StatusId,
                    CreateDate = DateTime.Now
                };

                await _articleCategoryWriteRepository.AddAsync(articleCategory);
                await _articleCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };

            }

        }

        public async Task<GetByIdArticleCategoryQueryResponse> GetByIdArticleCategoryAsync(int id)
        {
            VM_ArticleCategory? vM_ArticleCategory = await _articleCategoryReadRepository.GetWhere(x => x.Id == id)
                .Select(s => new VM_ArticleCategory
                {
                    Id = s.Id,
                    CategoryName = s.CategoryName,
                    CreateUserId = s.CreateUserId,
                    LangId = s.LangId,
                    MetaKey = s.MetaKey,
                    MetaDescription = s.MetaDescription,
                    MetaTitle = s.MetaTitle,
                    ParentId = s.ParentId,
                    StatusId = s.StatusId
                }).FirstOrDefaultAsync();

            if (vM_ArticleCategory != null)
            {
                List<VM_ArticleCategory> vM_ArticleCategories = await _articleCategoryReadRepository.GetAll()
                .Select(x => new VM_ArticleCategory
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
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

                return new()
                {
                    ArticleCategories = vM_ArticleCategories,
                    ArticleCategory = vM_ArticleCategory,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    ArticleCategories = null,
                    ArticleCategory = null,
                    Languages = null,
                    Statuses = null,
                    State = false,
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır."
                };
            }

        }

        public async Task<ArticleCategoryUpdateCommandResponse> ArticleCategoryUpdateAsync(ArticleCategoryUpdateCommandRequest request)
        {
            ArticleCategory articleCategory = await _articleCategoryReadRepository.GetByIdAsync(request.Id);

            if (articleCategory != null)
            {
                articleCategory.ParentId = request.ParentId > 0 ? request.ParentId : null;
                articleCategory.StatusId = request.StatusId;
                articleCategory.CategoryName = request.CategoryName;
                articleCategory.LangId = request.LangId;
                articleCategory.MetaDescription = request.MetaDescription;
                articleCategory.MetaKey = request.MetaKey;
                articleCategory.MetaTitle = request.MetaTitle;

                _articleCategoryWriteRepository.Update(articleCategory);
                await _articleCategoryWriteRepository.SaveAsync();

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
                    Message = "Bu bilgilere ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<ArticleCategoryDeleteCommandResponse> ArticleCategoryDeleteAsync(int id)
        {
            ArticleCategory articleCategory = await _articleCategoryReadRepository.GetByIdAsync(id);

            if (articleCategory != null)
            {
                int state = await _statusReadRepository.GetWhere(x=> x.StatusName == "Pasif").Select(x=> x.Id).FirstAsync();
                articleCategory.StatusId = state;
                
                _articleCategoryWriteRepository.Update(articleCategory);
                await _articleCategoryWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion

    }
}
