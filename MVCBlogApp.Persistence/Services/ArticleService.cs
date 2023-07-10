using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleCreate;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleDelete;
using MVCBlogApp.Application.Features.Commands.Article.Article.ArticleUpdate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetAllArticle;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetArticleCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.Article.GetByIdArticle;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory;
using MVCBlogApp.Application.Repositories.Article;
using MVCBlogApp.Application.Repositories.ArticleCategory;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Application.Repositories.Navigation;
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
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly IMasterRootReadRepository _masterRootReadRepository;
        private readonly IMasterRootWriteRepository _masterRootWriteRepository;
        private readonly IStorageService _storageService;

        public ArticleService(
            ILanguagesReadRepository languagesReadRepository,
            IStatusReadRepository statusReadRepository,
            IArticleCategoryReadRepository articleCategoryReadRepository,
            IArticleCategoryWriteRepository articleCategoryWriteRepository,
            INavigationReadRepository navigationReadRepository,
            IArticleReadRepository articleReadRepository,
            IArticleWriteRepository articleWriteRepository,
            IMasterRootReadRepository masterRootReadRepository,
            IMasterRootWriteRepository masterRootWriteRepository,
            IStorageService storageService)
        {
            _languagesReadRepository = languagesReadRepository;
            _statusReadRepository = statusReadRepository;
            _articleCategoryReadRepository = articleCategoryReadRepository;
            _articleCategoryWriteRepository = articleCategoryWriteRepository;
            _navigationReadRepository = navigationReadRepository;
            _articleReadRepository = articleReadRepository;
            _articleWriteRepository = articleWriteRepository;
            _masterRootReadRepository = masterRootReadRepository;
            _masterRootWriteRepository = masterRootWriteRepository;
            _storageService = storageService;
        }


        #region Article

        public async Task<GetArticleCreateItemsQueryResponse> GetArticleCreateItemsAsync()
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

            List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll()
                .Select(x => new VM_Navigation
                {
                    Id = x.Id,
                    NavigationName = x.NavigationName
                }).ToListAsync();

            return new()
            {
                ArticleCategories = vM_ArticleCategories,
                Languages = vM_Languages,
                Navigations = vM_Navigations,
                Statuses = allStatuses
            };

        }

        public async Task<GetAllArticleQueryResponse> GetAllArticleAsync()
        {
            List<VM_Article> vM_Articles = await _articleReadRepository.GetAll()
                .Join(_languagesReadRepository.GetAll(), ar => ar.LangId, lg => lg.Id, (ar, lg) => new { ar, lg })
                .Join(_statusReadRepository.GetAll(), art => art.ar.StatusId, st => st.Id, (art, st) => new { art, st })
                .Join(_articleCategoryReadRepository.GetAll(), article => article.art.ar.ArticleCategoryId, cn => cn.Id, (article, cn) => new { article, cn })
                .Select(x => new VM_Article
                {
                    Id = x.article.art.ar.Id,
                    Title = x.article.art.ar.Title,
                    SubTitle = x.article.art.ar.SubTitle,
                    CategoryName = x.cn.CategoryName,
                    Language = x.article.art.lg.Language,
                    StatusName = x.article.st.StatusName,
                    CreateDate = x.article.art.ar.CreateDate,
                    UpdateDate = x.article.art.ar.UpdateDate
                }).ToListAsync();

            return new()
            {
                Articles = vM_Articles
            };
        }

        public async Task<ArticleCreateCommandResponse> ArticleCreateAsync(ArticleCreateCommandRequest request)
        {
            var check = await _articleReadRepository
                .GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

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
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("article-files", request.FormFile);

                Article article = new()
                {
                    Controller = "Article",
                    Action = "Index",
                    CreateDate = DateTime.Now,
                    ArticleCategoryId = request.ArticleCategoryId,
                    Description = request.Description,
                    IsComponent = request.IsComponent,
                    IsMainPage = request.IsMainPage,
                    IsMenu = request.IsMenu,
                    IsNewsComponent = request.IsNewsComponent,
                    LangId = request.LangId,
                    MetaDescription = request.MetaDescription,
                    MetaKey = request.MetaKey,
                    MetaTitle = request.MetaTitle,
                    NavigationId = request.NavigationId,
                    Orders = request.Orders > 0 ? request.Orders : 0,
                    StatusId = request.StatusId,
                    SubTitle = request.SubTitle,
                    Title = request.Title,
                    UrlRoot = request.UrlRoot,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : null,
                    CoverImgUrl = result[0].pathOrContainerName
                };

                await _articleWriteRepository.AddAsync(article);
                await _articleWriteRepository.SaveAsync();

                MasterRoot masterRoot = new()
                {
                    Controller = "Article",
                    Action = "Index",
                    UrlRoot = request.UrlRoot
                };

                await _masterRootWriteRepository.AddAsync(masterRoot);
                await _masterRootWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetByIdArticleQueryResponse> GetByIdArticleAsync(int id)
        {
            VM_Article? vM_Article = await _articleReadRepository.GetWhere(x => x.Id == id)
                .Select(x => new VM_Article
                {
                    Id = x.Id,
                    ArticleCategoryId = x.ArticleCategoryId,
                    Description = x.Description,
                    IsComponent = x.IsComponent,
                    IsMainPage = x.IsMainPage,
                    IsMenu = x.IsMenu,
                    IsNewsComponent = x.IsNewsComponent,
                    LangId = x.LangId,
                    MetaDescription = x.MetaDescription,
                    MetaKey = x.MetaKey,
                    MetaTitle = x.MetaTitle,
                    NavigationId = x.NavigationId,
                    Orders = x.Orders,
                    StatusId = x.StatusId,
                    SubTitle = x.SubTitle,
                    Title = x.Title,
                    UrlRoot = x.UrlRoot
                }).FirstOrDefaultAsync();

            if (vM_Article != null)
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

                List<VM_Navigation> vM_Navigations = await _navigationReadRepository.GetAll()
                    .Select(x => new VM_Navigation
                    {
                        Id = x.Id,
                        NavigationName = x.NavigationName
                    }).ToListAsync();

                return new()
                {
                    Article = vM_Article,
                    ArticleCategories = vM_ArticleCategories,
                    Languages = vM_Languages,
                    Statuses = allStatuses,
                    Navigations = vM_Navigations,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Article = null,
                    ArticleCategories = null,
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<ArticleUpdateCommandResponse> ArticleUpdateAsync(ArticleUpdateCommandRequest request)
        {
            Article article = await _articleReadRepository.GetByIdAsync(request.Id);

            if (article != null)
            {
                MasterRoot? masterRoot = await _masterRootReadRepository.GetWhere(x => x.UrlRoot == article.UrlRoot).FirstOrDefaultAsync();
                if (masterRoot != null)
                {
                    masterRoot.UrlRoot = request.UrlRoot;
                    _masterRootWriteRepository.Update(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }
                else
                {
                    masterRoot = new()
                    {
                        Controller = "Article",
                        Action = "Index",
                        UrlRoot = request.UrlRoot
                    };

                    await _masterRootWriteRepository.AddAsync(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }

                if (request.FormFile != null)
                {
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("article-files", request.FormFile);
                    article.CoverImgUrl = result[0].pathOrContainerName;
                }

                article.Title = request.Title;
                article.Description = request.Description;
                article.MetaDescription = request.MetaDescription;
                article.ArticleCategoryId = request.ArticleCategoryId;
                article.IsComponent = request.IsComponent;
                article.IsNewsComponent = request.IsNewsComponent;
                article.IsMenu = request.IsMenu;
                article.LangId = request.LangId;
                article.UrlRoot = request.UrlRoot;
                article.NavigationId = request.NavigationId;
                article.Orders = request.Orders > 0 ? request.Orders : null;
                article.MetaTitle = request.MetaTitle;
                article.MetaKey = request.MetaKey;
                article.IsMainPage = request.IsMainPage;
                article.SubTitle = request.SubTitle;
                article.StatusId = request.StatusId;
                article.UpdateUserId = request.UpdateUserId > 0 ? request.UpdateUserId : null;
                article.UpdateDate = DateTime.Now;

                _articleWriteRepository.Update(article);
                await _articleWriteRepository.SaveAsync();

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
                    Message = "Bu bilgilere sahip bir kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<ArticleDeleteCommandResponse> ArticleDeleteAsync(int id)
        {
            Article article = await _articleReadRepository.GetByIdAsync(id);
            if (article != null)
            {
                int state = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
                article.StatusId = state;

                _articleWriteRepository.Update(article);
                await _articleWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunamamıştır.",
                    State = false
                };
            }
        }

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
                .Select(x => new AllStatus
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
                int state = await _statusReadRepository.GetWhere(x => x.StatusName == "Pasif").Select(x => x.Id).FirstAsync();
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
