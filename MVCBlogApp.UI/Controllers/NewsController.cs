using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperDelete;
using MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperUpdate;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetAllNewsBulletin;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetByIdNews;
using MVCBlogApp.Application.Features.Queries.News.NewsBulletin.GetNewsBulletinCreateItem;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetAllNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetByIdNewsPaper;
using MVCBlogApp.Application.Features.Queries.News.NewsPaper.GetNewsPaperCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class NewsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService  _operationService;

        public NewsController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region NewsBulletin

        [HttpGet]
        public async Task<IActionResult> NewsBulletinList(GetAllNewsBulletinQueryRequest request)
        {
            GetAllNewsBulletinQueryResponse response = await _mediator.Send(request);
            return View(response.NewsBulletins);
        }

        [HttpGet]
        public async Task<IActionResult> NewsBulletinCreate(GetNewsBulletinCreateItemQueryRequest request)
        {
            GetNewsBulletinCreateItemQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> NewsBulletinCreate(NewsBulletinCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            NewsBulletinCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NewsBulletinList", "News");
            }
            else
            {
                return RedirectToAction("NewsBulletinCreate", "News");
            }
        }

        [HttpGet]
        public async Task<IActionResult> NewsBulletinUpdate(GetByIdNewsQueryRequest request)
        {
            GetByIdNewsQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("NewsBulletinList", "News");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewsBulletinUpdate(NewsBulletinUpdateCommandRequest request)
        {
            NewsBulletinUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NewsBulletinList", "News");
            }
            else
            {
                return RedirectToAction("NewsBulletinUpdate", "News");
            }
        }

        public async Task<IActionResult> NewsBulletinDelete(NewsBulletinDeleteCommandRequest request)
        {
            NewsBulletinDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("NewsBulletinList", "News");
        }

        #endregion

        #region NewsPaper

        [HttpGet]
        public async Task<IActionResult> NewsPaperList(GetAllNewsPaperQueryRequest request)
        {
            GetAllNewsPaperQueryResponse response = await _mediator.Send(request);
            return View(response.NewsPapers);
        }

        [HttpGet]
        public async Task<IActionResult> NewsPaperCreate(GetNewsPaperCreateItemsQueryRequest request)
        {
            GetNewsPaperCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> NewsPaperCreate(NewsPaperCreateCommandRequest request)
        {
            NewsPaperCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NewsPaperList", "News");
            }
            else
            {
                return RedirectToAction("NewsPaperCreate", "News");
            }
        }

        [HttpGet]
        public async Task<IActionResult> NewsPaperUpdate(GetByIdNewsPaperQueryRequest request)
        {
            GetByIdNewsPaperQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("NewsPaperList", "News");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewsPaperUpdate(NewsPaperUpdateCommandRequest request)
        {
            NewsPaperUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("NewsPaperList", "News");
            }
            else
            {
                return RedirectToAction("NewsPaperUpdate", "News");
            }
        }

        public async Task<IActionResult> NewsPaperDelete(NewsPaperDeleteCommandRequest request)
        {
            NewsPaperDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("NewsPaperList", "News");
        }

        #endregion
    }
}
