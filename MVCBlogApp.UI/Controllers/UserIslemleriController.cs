using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserIslemleriController : Controller
    {
        #region Member

        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserDelete()
        {
            return View();
        }

        #endregion

        #region MemberInformation

        [HttpGet]
        public IActionResult UserInformationList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserInformationCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserInformationCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserInformationUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserInformationUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserInformationDelete()
        {
            return View();
        }

        #endregion

        #region MemberNutritionist

        [HttpGet]
        public IActionResult UserNutritionistList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserNutritionistCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserNutritionistCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserNutritionistUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserNutritionistUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserNutritionistDelete()
        {
            return View();
        }

        #endregion

        #region MemberAppointment

        [HttpGet]
        public IActionResult UserAppointmentList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserAppointmentCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAppointmentCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserAppointmentUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAppointmentUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserAppointmentDelete()
        {
            return View();
        }

        #endregion
    }
}
