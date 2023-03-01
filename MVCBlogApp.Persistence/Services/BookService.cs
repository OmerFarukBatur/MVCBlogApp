using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory;
using MVCBlogApp.Application.Repositories.BookCategory;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class BookService : IBookService
    {
        private readonly IBookCategoryReadRepository _bookCategoryReadRepository;
        private readonly IBookCategoryWriteRepository _bookCategoryWriteRepository;
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly ILanguagesReadRepository _languagesReadRepository;

        public BookService(
            IBookCategoryReadRepository bookCategoryReadRepository,
            IBookCategoryWriteRepository bookCategoryWriteRepository,
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository
            )
        {
            _bookCategoryReadRepository = bookCategoryReadRepository;
            _bookCategoryWriteRepository = bookCategoryWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
        }

        #region BookCategory

        public async Task<GetBookCatgoryCreateItemCommandResponse> GetBookCatgoryCreateItemAsync()
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

            return new()
            {
                Languages = vM_Languages,
                Statuses = allStatus
            };
        }

        public async Task<BookCategoryCreateCommandResponse> BookCategoryCreateAsync(BookCategoryCreateCommandRequest request)
        {
            var bookCategoryCheck = await _bookCategoryReadRepository
                .GetWhere(x => x.CategoryName.Trim().ToLower() == request.CategoryName.Trim().ToLower() || x.CategoryName.Trim().ToUpper() == request.CategoryName.Trim().ToUpper()).ToListAsync();

            if (bookCategoryCheck.Count > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                BookCategory bookCategory = new()
                {
                    CategoryName = request.CategoryName,
                    CreateUserId = request.CreateUser != null ? request.CreateUser : null,
                    CreateDate = DateTime.Now,
                    LangId = request.LangId,
                    StatusId = request.StatusId
                };

                await _bookCategoryWriteRepository.AddAsync(bookCategory);
                await _bookCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Bilgiler başarıyla kayıt edilmiştir.",
                    State = true
                };
            }
        }

        public async Task<GetAllBookCategoryCommandResponse> GetAllBookCategoriesAsync()
        {
            List<VM_BookCategory> vM_BookCategories = await _bookCategoryReadRepository
                .GetAll()
                .Join(_languagesReadRepository.GetAll(),bc=> bc.LangId,la=> la.Id, (bc, la) => new {bc,la})
                .Join(_statusReadRepository.GetAll(),bg=> bg.bc.StatusId,st=>st.Id,(bg,st)=> new {bg,st})
                .Select(x=> new VM_BookCategory
                {
                    CategoryName=x.bg.bc.CategoryName,
                    CreateDate=x.bg.bc.CreateDate,
                    Id = x.bg.bc.Id,
                    CreateUserId = x.bg.bc.CreateUserId,
                    StatusId = x.bg.bc.StatusId,
                    LangId = x.bg.bc.LangId,
                    Language = x.bg.la.Language,
                    StatusName = x.st.StatusName
                }).ToListAsync();

            return new()
            {
                BookCategories = vM_BookCategories
            };
        }

        public async Task<GetByIdBookCategoryQueryResponse> GetByIdBookCategoryAsync(GetByIdBookCategoryQueryRequest request)
        {
            VM_BookCategory? vM_BookCategory = await _bookCategoryReadRepository
                .GetWhere(x=> x.Id == request.Id)
                .Select(s=> new VM_BookCategory
                {
                    Id = s.Id,
                    CategoryName = s.CategoryName,
                    CreateDate = s.CreateDate,
                    CreateUserId= s.CreateUserId,
                    LangId= s.LangId,
                    StatusId= s.StatusId
                }).FirstOrDefaultAsync();

            if (vM_BookCategory != null)
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

                return new()
                {
                    BookCategory = vM_BookCategory,
                    Languages = vM_Languages,
                    Statuses = allStatus,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bu bilgilere ait kayıt bulunmamaktadır."
                };
            }
        }

        public async Task<BookCategoryUpdateCommandResponse> BookCategoryUpdateAsync(BookCategoryUpdateCommandRequest request)
        {
            BookCategory bookCategory = await _bookCategoryReadRepository.GetByIdAsync(request.Id);

            if (bookCategory != null)
            {
                bookCategory.CategoryName = request.CategoryName;
                bookCategory.StatusId = request.StatusId;
                bookCategory.LangId = request.LangId;

                _bookCategoryWriteRepository.Update(bookCategory);
                await _bookCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "İşlem başarıyla yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bilgilere sahip kayıt bulunanamıştır."
                };
            }
        }

        public async Task<BookCategoryDeleteCommandResponse> BookCategoryDeleteAsync(BookCategoryDeleteCommandRequest request)
        {
            BookCategory bookCategory = await _bookCategoryReadRepository.GetByIdAsync(request.Id);

            if (bookCategory != null)
            {
                _bookCategoryWriteRepository.Remove(bookCategory);
                await _bookCategoryWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Silme işlemi başarıyla gerçekleştirilmiştir.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere sahip kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }


        #endregion
    }
}
