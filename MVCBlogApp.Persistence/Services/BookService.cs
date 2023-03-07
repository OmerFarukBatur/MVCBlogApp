using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Application.Features.Commands.Book.BookCreate;
using MVCBlogApp.Application.Features.Commands.Book.BookDelete;
using MVCBlogApp.Application.Features.Commands.Book.BookUpdate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Book.GetAllBook;
using MVCBlogApp.Application.Features.Queries.Book.GetBookCreateItems;
using MVCBlogApp.Application.Features.Queries.Book.GetByIdBook;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory;
using MVCBlogApp.Application.Operations;
using MVCBlogApp.Application.Repositories.Book;
using MVCBlogApp.Application.Repositories.BookCategory;
using MVCBlogApp.Application.Repositories.Languages;
using MVCBlogApp.Application.Repositories.MasterRoot;
using MVCBlogApp.Application.Repositories.Navigation;
using MVCBlogApp.Application.Repositories.Status;
using MVCBlogApp.Application.Repositories.X_BookCategory;
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
        private readonly INavigationReadRepository _navigationReadRepository;
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IMasterRootWriteRepository _masterRootWriteRepository;
        private readonly IMasterRootReadRepository _masterRootReadRepository;
        private readonly IX_BookCategoryWriteRepository _x_BookCategoryWriteRepository;
        private readonly IX_BookCategoryReadRepository _x_BookCategoryReadRepository;

        public BookService(
            IBookCategoryReadRepository bookCategoryReadRepository,
            IBookCategoryWriteRepository bookCategoryWriteRepository,
            IStatusReadRepository statusReadRepository,
            ILanguagesReadRepository languagesReadRepository
,
            INavigationReadRepository navigationReadRepository,
            IBookReadRepository bookReadRepository,
            IBookWriteRepository bookWriteRepository,
            IStorageService storageService,
            IMasterRootWriteRepository masterRootWriteRepository,
            IX_BookCategoryWriteRepository x_BookCategoryWriteRepository,
            IX_BookCategoryReadRepository x_BookCategoryReadRepository,
            IMasterRootReadRepository masterRootReadRepository)
        {
            _bookCategoryReadRepository = bookCategoryReadRepository;
            _bookCategoryWriteRepository = bookCategoryWriteRepository;
            _statusReadRepository = statusReadRepository;
            _languagesReadRepository = languagesReadRepository;
            _navigationReadRepository = navigationReadRepository;
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _storageService = storageService;
            _masterRootWriteRepository = masterRootWriteRepository;
            _x_BookCategoryWriteRepository = x_BookCategoryWriteRepository;
            _x_BookCategoryReadRepository = x_BookCategoryReadRepository;
            _masterRootReadRepository = masterRootReadRepository;
        }


        #region Book

        public async Task<GetBookCreateItemsQueryResponse> GetBookCreateItemsAsync()
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

            List<VM_BookCategory> vM_BookCategory = await _bookCategoryReadRepository
                .GetAll()
                .Select(x => new VM_BookCategory
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                }).ToListAsync();


            return new()
            {
                Languages = vM_Languages,
                Navigations = vM_Navigations,
                Statuses = allStatus,
                BookCategories = vM_BookCategory
            };

        }

        public async Task<BookCreateCommandResponse> BookCreateAsync(BookCreateCommandRequest request)
        {
            var check = await _bookReadRepository
                .GetWhere(x => x.BookName.Trim().ToLower() == request.BookName.Trim().ToLower() || x.BookName.Trim().ToUpper() == request.BookName.Trim().ToUpper()).ToListAsync();

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

                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("book-files", request.FormFile);
                Book book = new()
                {
                    Action = "Edit",
                    Controller = "Book",
                    BookName = request.BookName,
                    Content = request.Content,
                    CreateDate = DateTime.Now,
                    CreateUserId = request.CreatedUserId > 0 ? request.CreatedUserId : null,
                    LangId = request.LangId,
                    NavigationId = request.NavigationId,
                    StatusId = request.StatusId,
                    Orders = 1,
                    ImageUrl = @"~\Upload\"+result[0].pathOrContainerName,
                    UrlRoot = NameOperation.GeneretaRootUrl(request.BookName),
                    PublicationYear = request.PublicationYear
                };

                await _bookWriteRepository.AddAsync(book);
                await _bookWriteRepository.SaveAsync();

                MasterRoot masterRoot = new()
                {
                    Controller = "Book",
                    Action = "Edit",
                    UrlRoot = NameOperation.GeneretaRootUrl(request.BookName),
                    CreateDate = DateTime.Now
                };

                await _masterRootWriteRepository.AddAsync(masterRoot);
                await _masterRootWriteRepository.SaveAsync();

                List<X_BookCategory> bookCategory = new();

                foreach (var item in request.BookCategoryId)
                {
                    bookCategory.Add(new()
                    {
                        BookCategoryId = item,
                        BookId = book.Id
                    });
                }

                await _x_BookCategoryWriteRepository.AddRangeAsync(bookCategory);
                await _x_BookCategoryWriteRepository.SaveAsync();


                return new()
                {
                    Message = "Bilgiler başarılı bir şekilde kayıt edilmiştir.",
                    State = true
                };
            }
        }


        public async Task<GetAllBookQueryResponse> GetAllBookAsync()
        {
            List<VM_Book> vM_Books = await _bookReadRepository
                 .GetAll()
                 .Join(_languagesReadRepository.GetAll(), bk => bk.LangId, lg => lg.Id, (bk, lg) => new { bk, lg })
                 .Join(_statusReadRepository.GetAll(), book => book.bk.StatusId, st => st.Id, (book, st) => new { book, st })
                 .Select(x => new VM_Book
                 {
                     Id = x.book.bk.Id,
                     BookName = x.book.bk.BookName,
                     Language = x.book.lg.Language,
                     StatusName = x.st.StatusName,
                     PublicationYear = x.book.bk.PublicationYear
                 }).ToListAsync();

            return new()
            {
                Books = vM_Books
            };
        }


        public async Task<GetByIdBookQueryResponse> GetByIdBookAsync(GetByIdBookQueryRequest request)
        {
            VM_Book? vM_Book = await _bookReadRepository
                .GetWhere(x=> x.Id == request.Id)
                .Select(x=> new VM_Book
                {
                    Id = x.Id,
                    BookName = x.BookName,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    LangId = x.LangId,
                    NavigationId = x.NavigationId,
                    PublicationYear = x.PublicationYear,
                    StatusId = x.StatusId,
                    UrlRoot = x.UrlRoot                     
                }).FirstOrDefaultAsync();

            if (vM_Book != null)
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

                List<VM_BookCategory> vM_BookCategory = await _bookCategoryReadRepository
                    .GetAll()
                    .Select(x => new VM_BookCategory
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName
                    }).ToListAsync();

                List<int> categoryIdList = await _x_BookCategoryReadRepository
                    .GetWhere(x=> x.BookId == request.Id)
                    .Select(x=> (int)x.BookCategoryId )
                    .ToListAsync();

                foreach (var item in vM_BookCategory)
                {
                    if (categoryIdList.Contains((int)item.Id))
                    {
                        item.SelectedState = true;
                    }
                    else
                    {
                        item.SelectedState = false;
                    }
                }

                return new()
                {
                    BookCategories = vM_BookCategory,
                    BookCategoryId = categoryIdList,
                    Books = vM_Book,
                    Languages = vM_Languages,
                    Navigations = vM_Navigations,
                    Statuses = allStatus,
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Books = null,
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    BookCategories = null,
                    BookCategoryId = null,
                    Message = "Bu bilgiye sahip kayıt bulunmamaktadır.",
                    State = false
                };
            }
        }

        public async Task<BookUpdateCommandResponse> BookUpdateAsync(BookUpdateCommandRequest request)
        {
            Book book = await _bookReadRepository.GetByIdAsync(request.Id);

            if (book != null)
            {
                MasterRoot? masterRoot = await _masterRootReadRepository.GetWhere(x=> x.UrlRoot == book.UrlRoot).FirstOrDefaultAsync();
                if (masterRoot != null)
                {
                    masterRoot.UrlRoot = NameOperation.GeneretaRootUrl(request.BookName);
                    _masterRootWriteRepository.Update(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }
                else
                {
                    masterRoot = new()
                    {
                        Controller = "Book",
                        Action = "Edit",
                        UrlRoot = NameOperation.GeneretaRootUrl(request.BookName),
                        CreateDate = DateTime.Now
                    };

                    await _masterRootWriteRepository.AddAsync(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }

                List<X_BookCategory> x_BookCategory = new();
                x_BookCategory = await _x_BookCategoryReadRepository.GetWhere(x => x.BookId == request.Id).ToListAsync();

                if (x_BookCategory.Count > 0)
                {
                    _x_BookCategoryWriteRepository.RemoveRange(x_BookCategory);
                    await _x_BookCategoryWriteRepository.SaveAsync();


                    List<X_BookCategory> x_BookCategory2 = new();
                    foreach (var item in request.BookCategoryId)
                    {
                        x_BookCategory2.Add(new()
                        {
                            BookCategoryId = item,
                            BookId = book.Id
                        });
                    }

                    await _x_BookCategoryWriteRepository.AddRangeAsync(x_BookCategory2);
                    await _x_BookCategoryWriteRepository.SaveAsync();
                }
                else
                {
                    foreach (var item in request.BookCategoryId)
                    {
                        x_BookCategory.Add(new()
                        {
                            BookCategoryId = item,
                            BookId = book.Id
                        });
                    }

                    await _x_BookCategoryWriteRepository.AddRangeAsync(x_BookCategory);
                    await _x_BookCategoryWriteRepository.SaveAsync();
                }            


                book.BookName = request.BookName;
                book.Content = request.Content;
                book.LangId = request.LangId;
                book.NavigationId = request.NavigationId;
                book.StatusId = request.StatusId;
                book.UrlRoot = NameOperation.GeneretaRootUrl(request.BookName);
                book.PublicationYear = request.PublicationYear;

                if (request.FormFile != null)
                {   
                    List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("book-files", request.FormFile);
                    book.ImageUrl = @"~\Upload\" + result[0].pathOrContainerName;                    
                }

                _bookWriteRepository.Update(book);
                await _bookWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Güncelleme başarılı bir şekilde yapılmıştır.",
                    State = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir veri bulunamamıştır.",
                    State = false
                };
            }
        }

        public async Task<BookDeleteCommandResponse> BookDeleteAsync(BookDeleteCommandRequest request)
        {
            Book book = await _bookReadRepository.GetByIdAsync(request.Id);

            if (book != null)
            {
                MasterRoot? masterRoot = await _masterRootReadRepository.GetWhere(x=> x.UrlRoot == book.UrlRoot).FirstOrDefaultAsync();
                if (masterRoot != null)
                {
                    _masterRootWriteRepository.Remove(masterRoot);
                    await _masterRootWriteRepository.SaveAsync();
                }

                List<X_BookCategory> category = await _x_BookCategoryReadRepository.GetWhere(x => x.BookId == request.Id).ToListAsync();

                if (category != null)
                {
                    _x_BookCategoryWriteRepository.RemoveRange(category);
                    await _x_BookCategoryWriteRepository.SaveAsync();
                }

                _bookWriteRepository.Remove(book);
                await _bookWriteRepository.SaveAsync();

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
                    State = false,
                    Message = "Bu bilgilere ait kayıt bulunamadı."
                };
            }
        }



        #endregion


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
                .Join(_languagesReadRepository.GetAll(), bc => bc.LangId, la => la.Id, (bc, la) => new { bc, la })
                .Join(_statusReadRepository.GetAll(), bg => bg.bc.StatusId, st => st.Id, (bg, st) => new { bg, st })
                .Select(x => new VM_BookCategory
                {
                    CategoryName = x.bg.bc.CategoryName,
                    CreateDate = x.bg.bc.CreateDate,
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
                .GetWhere(x => x.Id == request.Id)
                .Select(s => new VM_BookCategory
                {
                    Id = s.Id,
                    CategoryName = s.CategoryName,
                    CreateDate = s.CreateDate,
                    CreateUserId = s.CreateUserId,
                    LangId = s.LangId,
                    StatusId = s.StatusId
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
