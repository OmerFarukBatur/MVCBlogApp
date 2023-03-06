using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Blog.BlogCreate;
using MVCBlogApp.Application.Features.Commands.Blog.BlogDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Blog.GetAllBlog;
using MVCBlogApp.Application.Features.Queries.Blog.GetBlogCreateItems;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetBlogTypeCreateItems;
using MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType;
using MVCBlogApp.Application.Repositories.Blog;
using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.X_BlogCategory;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogTypeReadRepository _blogTypeReadRepository;
        private readonly IBlogTypeWriteRepository _blogTypeWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;
        private readonly IBlogCategoryReadRepository _categoryReadRepository;
        private readonly IBlogCategoryWriteRepository _categoryWriteRepository;
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IMasterRootReadRepository _masterRootReadRepository;
        private readonly IMasterRootWriteRepository _masterRootWriteRepository;
        private readonly IX_BlogCategoryReadRepository _xbCategoryReadRepository;
        private readonly IX_BlogCategoryWriteRepository _xbCategoryWriteRepository;

        public BlogService(IBlogTypeReadRepository blogTypeReadRepository, IBlogTypeWriteRepository blogTypeWriteRepository, IStatusReadRepository statusReadRepository, ILanguagesReadRepository languagesReadRepository, IBlogCategoryReadRepository categoryReadRepository, IBlogCategoryWriteRepository categoryWriteRepository, INavigationReadRepository navigationReadRepository, IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository, IStorageService storageService, IMasterRootReadRepository masterRootReadRepository, IMasterRootWriteRepository masterRootWriteRepository, IX_BlogCategoryReadRepository xbCategoryReadRepository, IX_BlogCategoryWriteRepository xbCategoryWriteRepository)
        {
            _blogTypeReadRepository = blogTypeReadRepository;
            _blogTypeWriteRepository = blogTypeWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _navigationReadRepository = navigationReadRepository;
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
            _storageService = storageService;
            _masterRootReadRepository = masterRootReadRepository;
            _masterRootWriteRepository = masterRootWriteRepository;
            _xbCategoryReadRepository = xbCategoryReadRepository;
            _xbCategoryWriteRepository = xbCategoryWriteRepository;
        }

        #region BlogType
        public async Task<BlogTypeCreateCommandResponse> BlogTypeCreateAsync(BlogTypeCreateCommandRequest request)
        {
            var blogType = await _blogTypeReadRepository.GetWhere(x => x.TypeName.Trim().ToLower() == request.TypeName.Trim().ToLower() || x.TypeName.Trim().ToUpper() == request.TypeName.Trim().ToUpper()).ToListAsync();

            if (blogType.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                BlogType newblogType = new() { TypeName = request.TypeName, LangId = request.LangId };

                await _blogTypeWriteRepository.AddAsync(newblogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Başarıyla kayıt edildi.",
                    State = true
                };
            }
        }

        public async Task<BlogTypeDeleteCommandResponse> BlogTypeDeleteAsync(BlogTypeDeleteCommandRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);

            if (blogType != null)
            {
                _blogTypeWriteRepository.Remove(blogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = "Silme işlemi sırasında beklenmedik bir hata ile karşılaşıldı."
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bu bilgilere ait ver bulunmamaktadır.."
                };
            }
        }

        public async Task<BlogTypeUpdateCommandResponse> BlogTypeUpdateAsync(BlogTypeUpdateCommandRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);
            if (blogType != null)
            {
                blogType.TypeName = request.TypeName;
                blogType.LangId = request.LangId;

                _blogTypeWriteRepository.Update(blogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false
                };
            }
        }

        public async Task<GetAllBlogTypeQueryResponse> GetAllBlogTypeAsync()
        {
            List<VM_BlogType> vM_BlogTypes = await _blogTypeReadRepository
                .GetAll()
                .Join(_languagesReadRepository.GetAll(), bl => bl.LangId, la => la.Id, (bl, la) => new { bl, la })
                .Select(x => new VM_BlogType()
                {
                    Id = x.bl.Id,
                    TypeName = x.bl.TypeName,
                    LangId = x.bl.LangId,
                    Language = x.la.Language
                }).ToListAsync();

            return new()
            {
                BlogTypes = vM_BlogTypes
            };
        }

        public async Task<GetByIdBlogTypeQueryResponse> GetByIdBlogTypeAsync(GetByIdBlogTypeQueryRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);

            if (blogType != null)
            {
                List<VM_Language> vM_Language = await _languagesReadRepository.GetAll().Select(x => new VM_Language
                {
                    Id = x.Id,
                    IsActive = (bool)x.IsActive,
                    Language = x.Language
                }).ToListAsync();

                return new()
                {
                    BlogType = new()
                    {
                        Id = blogType.Id,
                        TypeName = blogType.TypeName,
                        LangId = blogType.LangId,
                        Languages = vM_Language
                    },
                    State = true
                };
            }
            else
            {
                return new()
                {
                    BlogType = null,
                    State = false,
                    Message = "Bu bilgiye sahip bir veri bulunmamaktadır."
                };
            }
        }


        public async Task<GetBlogTypeCreateItemsQueryResponse> GetBlogTypeCreateItemsAsync()
        {
            List<VM_Language> vM_Language = await _languagesReadRepository.GetAll().Select(x => new VM_Language
            {
                Id = x.Id,
                IsActive = (bool)x.IsActive,
                Language = x.Language
            }).ToListAsync();

            return new()
            {
                Languages = vM_Language
            };
        }

        #endregion

        #region BlogCategory

        public async Task<GetBlogCategoryItemQueryResponse> GetBlogCategoryItemAsync()
        {
            List<AllStatus> allStatus = await _statusReadRepository.GetAll().Select(x => new AllStatus()
            {
                Id = x.Id,
                StatusName = x.StatusName
            }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language()
            {
                Language = x.Language,
                Id = x.Id,
                IsActive = (bool)x.IsActive
            }).ToListAsync();

            return new()
            {
                Languages = vM_Languages,
                Status = allStatus
            };
        }

        public async Task<BlogCategoryCreateCommandResponse> BlogCategoryCreateAsync(BlogCategoryCreateCommandRequest request)
        {
            var category = await _categoryReadRepository.GetWhere(a => a.CategoryName.Trim().ToLower() == request.CategoryName.Trim().ToLower() || a.CategoryName.Trim().ToUpper() == request.CategoryName.Trim().ToUpper()).ToListAsync();

            if (category.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                BlogCategory blogCategory = new()
                {
                    CategoryName = request.CategoryName,
                    CategoryDescription = request.CategoryDescription,
                    StatusId = request.StatusId,
                    LangId = request.LangId
                };

                await _categoryWriteRepository.AddAsync(blogCategory);
                await _categoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt işlemi başarıyla yapılmıştır.",
                    State = true
                };
            }
        }

        public async Task<GetAllBlogCategoryQueryResponse> GetAllBlogCategoryAsync()
        {
            List<VM_AllBlogCategory> blogCategories = await _categoryReadRepository.GetAll()
                .Join(_statusReadRepository.GetAll(false), ca => ca.StatusId, st => st.Id, (ca, st) => new { ca, st })
                .Join(_languagesReadRepository.GetAll(false), cate => cate.ca.LangId, x => x.Id, (cate, x) => new { cate, x })
                .Select(z => new VM_AllBlogCategory
                {
                    Id = z.cate.ca.Id,
                    CatgoryName = z.cate.ca.CategoryName,
                    CategoryDescription = z.cate.ca.CategoryDescription,
                    Status = new()
                    {
                        Id = z.cate.st.Id,
                        StatusName = z.cate.st.StatusName,
                    },
                    Languages = new()
                    {
                        Id = z.x.Id,
                        Language = z.x.Language,
                        IsActive = z.x.IsActive
                    }

                }).ToListAsync();

            return new()
            {
                AllCategory = blogCategories
            };
        }

        public async Task<GetByIdBlogCategoryQueryResponse> GetByIdBlogCategoryAsync(GetByIdBlogCategoryQueryRequest request)
        {
            BlogCategory blogCategory = await _categoryReadRepository.GetByIdAsync(request.Id);
            if (blogCategory != null)
            {
                List<AllStatus> AllStatus = await _statusReadRepository.GetAll().Select(z => new AllStatus
                {
                    Id = z.Id,
                    StatusName = z.StatusName
                }).ToListAsync();


                List<VM_Language> vM_Language = await _languagesReadRepository.GetAll().Select(s => new VM_Language
                {
                    Id = s.Id,
                    Language = s.Language,
                    IsActive = (bool)s.IsActive
                }).ToListAsync();

                return new()
                {
                    BlogCategory = new()
                    {
                        ID = blogCategory.Id,
                        CategoryDescription = blogCategory.CategoryDescription,
                        CategoryName = blogCategory.CategoryName,
                        LangID = (int)blogCategory.LangId,
                        StatusID = (int)blogCategory.StatusId,
                    },
                    AllStatuses = AllStatus,
                    AllLanguages = vM_Language,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    AllLanguages = null,
                    AllStatuses = null,
                    BlogCategory = null
                };
            }
        }

        public async Task<BlogCategoryUpdateQueryResponse> BlogCategoryUpdateAsync(BlogCategoryUpdateQueryRequest request)
        {
            BlogCategory blogCategory = await _categoryReadRepository.GetByIdAsync(request.Id);

            if (blogCategory != null)
            {
                blogCategory.CategoryName = request.CategoryName;
                blogCategory.CategoryDescription = request.CategoryDescription;
                blogCategory.StatusId = request.StatusId;
                blogCategory.LangId = request.LangId;

                _categoryWriteRepository.Update(blogCategory);
                await _categoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla gerçekleştirildi.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sıarasında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }

        public async Task<BlogCategoryDeleteCommandResponse> BlogCategoryDeleteAsync(BlogCategoryDeleteCommandRequest request)
        {
            BlogCategory blogCategory = await _categoryReadRepository.GetByIdAsync(request.Id);

            if (blogCategory != null)
            {
                _categoryWriteRepository.Remove(blogCategory);
                await _categoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla gerçekleştirildi.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "İşlem sıarsında beklenmedik bir hata oluştu.",
                    State = false
                };
            }
        }


        #endregion

        #region Blog

        public async Task<GetBlogCreateItemsQueryResponse> GetBlogCreateItemsAsync()
        {
            List<VM_Language> vM_Languages = await _languagesReadRepository
                .GetAll()
                .Select(x => new VM_Language
                {
                    Id = x.Id,
                    IsActive = (bool)x.IsActive,
                    Language = x.Language
                }).ToListAsync();

            List<AllStatus> allStatus = await _statusReadRepository
                .GetAll()
                .Select(x => new AllStatus
                {
                    Id = x.Id,
                    StatusName = x.StatusName
                }).ToListAsync();

            List<VM_Navigation> vM_Navigations = await _navigationReadRepository
                .GetAll()
                .Select(x => new VM_Navigation
                {
                    Id = x.Id,
                    NavigationName = x.NavigationName
                }).ToListAsync();

            List<VM_BlogCategory> vM_BlogCategories = await _categoryReadRepository
                .GetAll()
                .Select(x => new VM_BlogCategory
                {
                    ID = x.Id,
                    CategoryName = x.CategoryName
                }).ToListAsync();

            List<VM_BlogType> vM_BlogTypes = await _blogTypeReadRepository
                .GetAll()
                .Select(x => new VM_BlogType
                {
                    Id = x.Id,
                    TypeName = x.TypeName
                }).ToListAsync();

            return new()
            {
                BlogCategories = vM_BlogCategories,
                BlogTypes = vM_BlogTypes,
                Navigations = vM_Navigations,
                Languages = vM_Languages,
                Statuses = allStatus
            };

        }

        public async Task<BlogCreateCommandResponse> BlogCreateAsync(BlogCreateCommandRequest request)
        {
            var blogCheck = await _blogReadRepository.GetWhere(x => x.Title.Trim().ToLower() == request.Title.Trim().ToLower() || x.Title.Trim().ToUpper() == request.Title.Trim().ToUpper()).ToListAsync();

            if (blogCheck.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("blog-files", request.FormFile);
                Blog blog = new()
                {
                    BlogTypeId = request.BlogTypeId,
                    Title = request.Title,
                    Contents = request.Contents,
                    CoverImgUrl = @"~\Upload\" + result[0].pathOrContainerName,
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreateUserId > 0 ? request.CreateUserId : 0,
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
                    UrlRoot = request.UrlRoot
                };

                await _blogWriteRepository.AddAsync(blog);
                await _blogWriteRepository.SaveAsync();

                MasterRoot masterRoot = new MasterRoot()
                {
                    Controller = "Blog",
                    Action = "Detail",
                    UrlRoot = request.UrlRoot
                };

                await _masterRootWriteRepository.AddAsync(masterRoot);
                await _masterRootWriteRepository.SaveAsync();


                List<X_BlogCategory> xBlogCategory = new();

                foreach (var item in request.BlogCategoryId)
                {
                    xBlogCategory.Add(new X_BlogCategory()
                    {
                        BlogCategoryId = item,
                        BlogId = blog.Id
                    });
                }

                await _xbCategoryWriteRepository.AddRangeAsync(xBlogCategory);
                await _xbCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Blog başarılı bir şekilde kayıt edildi.",
                    State = true
                };
            }
        }

        public async Task<GetAllBlogQueryResponse> GetAllBlogAsync()
        {
            List<VM_Blog> vM_Blogs = await _blogReadRepository
                .GetAll()
                .Join(_languagesReadRepository.GetAll(), b => b.LangId, lg => lg.Id, (b, lg) => new { b, lg })
                .Join(_statusReadRepository.GetAll(), bl => bl.b.StatusId, st => st.Id, (bl, st) => new { bl, st })
                .Join(_blogTypeReadRepository.GetAll(), blo => blo.bl.b.BlogTypeId, bt => bt.Id, (blo, bt) => new { blo, bt })
                .Join(_navigationReadRepository.GetAll(), blog => blog.blo.bl.b.NavigationId, ng => ng.Id, (blog, ng) => new { blog, ng })
                .Select(x => new VM_Blog
                {
                    Id = x.blog.blo.bl.b.Id,
                    Title = x.blog.blo.bl.b.Title,
                    UrlRoot = x.blog.blo.bl.b.UrlRoot,
                    BlogTypeName = x.blog.bt.TypeName,
                    Language = x.blog.blo.bl.lg.Language,
                    StatusName = x.blog.blo.st.StatusName,
                    CreateDate = x.blog.blo.bl.b.CreateDate,
                    UpdateDate = x.blog.blo.bl.b.UpdateDate
                }).ToListAsync();

            return new()
            {
                Blogs = vM_Blogs
            };
        }

        public async Task<BlogDeleteCommandResponse> BlogDeleteAsync(BlogDeleteCommandRequest request)
        {
            Blog blog = await _blogReadRepository.GetByIdAsync(request.Id);

            if (blog != null)
            {
                MasterRoot? masterRoot = await _masterRootReadRepository.GetWhere(x=> x.UrlRoot == blog.UrlRoot).FirstOrDefaultAsync();

                if (masterRoot != null)
                {
                    _masterRootWriteRepository.Remove(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }

                List<X_BlogCategory> x_BlogCategories = await _xbCategoryReadRepository.GetWhere(x => x.BlogId == blog.Id).ToListAsync();

                if (x_BlogCategories != null)
                {
                    _xbCategoryWriteRepository.RemoveRange(x_BlogCategories);
                    await _xbCategoryWriteRepository.SaveAsync();
                }

                _blogWriteRepository.Remove(blog);
                await _blogWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla yapıldı.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bilgilere ait kayıt bulunamamıştır.",
                    State = false
                };
            }
        }


        #endregion
    }
}
