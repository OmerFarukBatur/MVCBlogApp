using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryCreate;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryDelete;
using MVCBlogApp.Application.Features.Commands.File.VideoCategory.VideoCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetAllVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory;
using MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetVideoCategoryCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FileController : Controller
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Image
        public async Task<IActionResult> ImageList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpdate(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ImageDelete(int id)
        {
            return View();
        }

        #endregion

        #region VideoCategory
        public async Task<IActionResult> VideoCategoryList(GetAllVideoCategoryQueryRequest request)
        {
            GetAllVideoCategoryQueryResponse response = await _mediator.Send(request);
            return View(response.VideoCategories);
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryCreate(GetVideoCategoryCreateItemsQueryRequest request)
        {
            GetVideoCategoryCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryCreate(VideoCategoryCreateCommandRequest request)
        {
            VideoCategoryCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoCategoryList", "File");
            }
            else
            {
                return RedirectToAction("VideoCategoryCreate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryUpdate(GetByIdVideoCategoryQueryRequest request)
        {
            GetByIdVideoCategoryQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("VideoCategoryList", "File");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryUpdate(VideoCategoryUpdateCommandRequest request)
        {
            VideoCategoryUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("VideoCategoryList", "File");
            }
            else
            {
                return RedirectToAction("VideoCategoryUpdate", "File");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryDelete(VideoCategoryDeleteCommandRequest request)
        {
            VideoCategoryDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("VideoCategoryList", "File");
        }

        #endregion

        #region Video
        public async Task<IActionResult> VideoList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VideoUpload(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VideoUpdate(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoDelete(int id)
        {
            return View();
        }

        #endregion
    }
}
