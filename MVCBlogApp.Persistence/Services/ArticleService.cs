using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;
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


        #endregion

    }
}
