using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
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


        #endregion
    }
}
