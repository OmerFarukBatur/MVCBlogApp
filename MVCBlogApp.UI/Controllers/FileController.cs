using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> VideoCategoryList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryCreate(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VideoCategoryUpdate(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VideoCategoryDelete(int id)
        {
            return View();
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
