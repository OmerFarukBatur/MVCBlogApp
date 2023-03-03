using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.Book.BookCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Book.GetAllBook;
using MVCBlogApp.Application.Features.Queries.Book.GetBookCreateItems;
using MVCBlogApp.Application.Features.Queries.Book.GetByIdBook;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetAllBookCategory;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetBookCatgoryCreateItem;
using MVCBlogApp.Application.Features.Queries.BookCategory.GetByIdBookCategory;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public BookController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Book

        public async Task<IActionResult> BookList(GetAllBookQueryRequest request)
        {
            GetAllBookQueryResponse response = await _mediator.Send(request);
            return View(response.Books);
        }

        [HttpGet]
        public async Task<IActionResult> BookCreate(GetBookCreateItemsQueryRequest request)
        {
            GetBookCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookCreateCommandRequest request)
        {
            request.CreatedUserId = _operationService.GetUser().Id;
            BookCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("BookList", "Book");
            }
            else
            {
                return RedirectToAction("BookCreate", "Book");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BookUpdate(GetByIdBookQueryRequest request)
        {
            GetByIdBookQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("BookList", "Book");
            }           
        }

        [HttpPost]
        public async Task<IActionResult> BookUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> BookDelete(int a)
        {
            return View();
        }

        #endregion

        #region BookCategory

        public async Task<IActionResult> BookCategoryList(GetAllBookCategoryCommandRequest request)
        {
            GetAllBookCategoryCommandResponse response = await _mediator.Send(request);
            return View(response.BookCategories);
        }

        [HttpGet]
        public async Task<IActionResult> BookCategoryCreate(GetBookCatgoryCreateItemCommandRequest request)
        {            
            GetBookCatgoryCreateItemCommandResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BookCategoryCreate(BookCategoryCreateCommandRequest request)
        {
            request.CreateUser = _operationService.GetUser().Id;
            BookCategoryCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("BookCategoryList", "Book");
            }
            else
            {
                return RedirectToAction("BookCategoryCreate", "Book");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BookCategoryUpdate(GetByIdBookCategoryQueryRequest request)
        {
            GetByIdBookCategoryQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("BookCategoryList", "Book");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> BookCategoryUpdate(BookCategoryUpdateCommandRequest request)
        {
            BookCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BookCategoryList", "Book");
            }
            else
            {
                return RedirectToAction("BookCategoryUpdate", "Book");
            }
        }

        public async Task<IActionResult> BookCategoryDelete(BookCategoryDeleteCommandRequest request)
        {
            BookCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("BookCategoryList", "Book");
        }

        #endregion
    }
}
