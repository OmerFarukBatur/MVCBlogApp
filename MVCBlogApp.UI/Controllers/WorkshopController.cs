using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WorkshopController : Controller
    {
        #region Workshop

        [HttpGet]
        public async Task<IActionResult> WorkshopList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopDelete(int a)
        {
            return View();
        }

        #endregion

        #region WorkShopApplicationForms

        [HttpGet]
        public async Task<IActionResult> WSAFList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WSAFCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WSAFCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WSAFUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WSAFUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WSAFDelete(int a)
        {
            return View();
        }

        #endregion

        #region WorkshopCategory

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCategoryCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopCategoryUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopCategoryUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopCategoryDelete(int a)
        {
            return View();
        }

        #endregion

        #region WorkshopEducation

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopEducationUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopEducationUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopEducationDelete(int a)
        {
            return View();
        }

        #endregion

        #region WorkshopType

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopTypeCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WorkshopTypeUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkshopTypeUpdate(int a)
        {
            return View();
        }

        public async Task<IActionResult> WorkshopTypeDelete(int a)
        {
            return View();
        }

        #endregion
    }
}
