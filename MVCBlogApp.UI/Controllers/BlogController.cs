using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete;
using MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Blog.GetBlogCreateItems;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem;
using MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetBlogTypeCreateItems;
using MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Blog
        public async Task<IActionResult> BlogList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BlogCreate(GetBlogCreateItemsQueryRequest request)
        {
            GetBlogCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BlogCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BlogUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogUpdate(int a)
        {
            return View();
        }

        
        public async Task<IActionResult> BlogDelete(int a)
        {
            return View();
        }
        #endregion

        #region BlogCategory
        public async Task<IActionResult> BlogCategoryList(GetAllBlogCategoryQueryRequest request)
        {
            GetAllBlogCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.AllCategory);
        }

        [HttpGet]
        public async Task<IActionResult> BlogCategoryCreate(GetBlogCategoryItemQueryRequest request)
        {
            GetBlogCategoryItemQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BlogCategoryCreate(BlogCategoryCreateCommandRequest request)
        {
            BlogCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BlogCategoryList", "Blog");
            }
            else
            {
                return RedirectToAction("BlogCategoryCreate", "Blog");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BlogCategoryUpdate(GetByIdBlogCategoryQueryRequest request)
        {
            GetByIdBlogCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(new{ response.BlogCategory,response.AllStatuses,response.AllLanguages});
            }
            else
            {
                return RedirectToAction("BlogCategoryList", "Blog");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> BlogCategoryUpdate(BlogCategoryUpdateQueryRequest request)
        {
            BlogCategoryUpdateQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("BlogCategoryList", "Blog");
            }
            else
            {
                return RedirectToAction("BlogCategoryUpdate", "Blog");
            }
        }


        public async Task<IActionResult> BlogCategoryDelete(BlogCategoryDeleteCommandRequest request)
        {
            BlogCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("BlogCategoryList", "Blog");
        }
        #endregion

        #region BlogType
        public async Task<IActionResult> BlogTypeList(GetAllBlogTypeQueryRequest request)
        {
            GetAllBlogTypeQueryResponse response = await _mediator.Send(request);
            return View(response.BlogTypes);
        }

        [HttpGet]
        public async Task<IActionResult> BlogTypeCreate(GetBlogTypeCreateItemsQueryRequest request)
        {
            GetBlogTypeCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> BlogTypeCreate(BlogTypeCreateCommandRequest request)
        {
            BlogTypeCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BlogTypeList","Blog");
            }
            else
            {
                return RedirectToAction("BlogTypeCreate", "Blog");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BlogTypeUpdate(GetByIdBlogTypeQueryRequest request)
        {
            GetByIdBlogTypeQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.BlogType);
            }
            else
            {
                return RedirectToAction("BlogTypeList", "Blog");
            }
        }

        [HttpPost]
        public async Task<IActionResult> BlogTypeUpdate(BlogTypeUpdateCommandRequest request)
        {
            BlogTypeUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("BlogTypeList", "Blog");
            }
            else
            {
                return RedirectToAction("BlogTypeUpdate", "Blog");
            }
        }


        public async Task<IActionResult> BlogTypeDelete(BlogTypeDeleteCommandRequest request)
        {
            BlogTypeDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("BlogTypeList", "Blog");
        }
        #endregion
    }
}
