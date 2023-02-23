using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType;
using MVCBlogApp.Application.Repositories.BlogCategory;
using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
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

        public BlogService(IBlogTypeReadRepository blogTypeReadRepository, IBlogTypeWriteRepository blogTypeWriteRepository, IStatusReadRepository statusReadRepository, ILanguagesReadRepository languagesReadRepository, IBlogCategoryReadRepository categoryReadRepository, IBlogCategoryWriteRepository categoryWriteRepository)
        {
            _blogTypeReadRepository = blogTypeReadRepository;
            _blogTypeWriteRepository = blogTypeWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
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
                BlogType newblogType = new() { TypeName = request.TypeName };

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
            List<VM_BlogType> vM_BlogTypes = await _blogTypeReadRepository.GetAll().Select(x => new VM_BlogType()
            {
                Id = x.ID,
                TypeName = x.TypeName
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
                return new()
                {
                    BlogType = new() { Id = blogType.ID, TypeName = blogType.TypeName },
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

        #endregion

        #region BlogCategory

        public async Task<GetBlogCategoryItemQueryResponse> GetBlogCategoryItemAsync()
        {
            List<AllStatus> allStatus = await _statusReadRepository.GetAll().Select(x => new AllStatus()
            {
                Id = x.ID,
                StatusName = x.StatusName
            }).ToListAsync();

            List<VM_Language> vM_Languages = await _languagesReadRepository.GetAll().Select(x => new VM_Language()
            {
                Language = x.Language,
                Id = x.ID,
                IsActive = x.IsActive
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
                    StatusID = request.StatusId,
                    LangID = request.LangId
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
                .Include(x => x.Status)
                .Join(_languagesReadRepository.GetAll(false), c => c.LangID, x => x.ID, (c, x) => new { c, x })
                .Select(z => new VM_AllBlogCategory
                {
                    Id = z.c.ID,
                    CatgoryName = z.c.CategoryName,
                    CategoryDescription = z.c.CategoryDescription,
                    Status = new()
                    {
                        ID = z.c.Status.ID,
                        StatusName = z.c.Status.StatusName
                    },
                    Languages = new()
                    {
                        ID = z.x.ID,
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
                    Id = z.ID,
                    StatusName = z.StatusName
                }).ToListAsync();


                List<VM_Language> vM_Language = await _languagesReadRepository.GetAll().Select(s => new VM_Language
                {
                    Id = s.ID,
                    Language = s.Language,
                    IsActive = s.IsActive
                }).ToListAsync();

                return new()
                {
                    BlogCategory = new()
                    {
                        ID = blogCategory.ID,
                        CategoryDescription = blogCategory.CategoryDescription,
                        CategoryName = blogCategory.CategoryName,
                        LangID = blogCategory.LangID,
                        StatusID = blogCategory.StatusID,
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
                blogCategory.StatusID = request.StatusId;
                blogCategory.LangID = request.LangId;

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

    }
}
