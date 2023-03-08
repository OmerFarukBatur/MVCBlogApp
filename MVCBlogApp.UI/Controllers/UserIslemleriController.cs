using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetAllUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetByIdUser;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.User.GetUserCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserIslemleriController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public UserIslemleriController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }


        #region Member

        [HttpGet]
        public async Task<IActionResult> UserList(GetAllUserQueryRequest request)
        {
            GetAllUserQueryResponse response = await _mediator.Send(request);
            return View(response.Members);
        }

        [HttpGet]
        public async Task<IActionResult> UserCreate(GetUserCreateItemsQueryRequest request)
        {
            GetUserCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(UserCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            UserCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("UserList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("UserCreate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserUpdate(GetByIdUserQueryRequest request)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("UserList", "UserIslemleri");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateCommandRequest request)
        {
            UserUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State) 
            {
                return RedirectToAction("UserList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("UserUpdate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserDelete(UserDeleteCommandRequest request)
        {
            UserDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("UserList", "UserIslemleri");
        }

        #endregion

        #region MemberInformation

        [HttpGet]
        public async Task<IActionResult> UserInformationList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserInformationCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserInformationCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserInformationUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserInformationUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserInformationDelete()
        {
            return View();
        }

        #endregion

        #region MemberNutritionist

        [HttpGet]
        public async Task<IActionResult> UserNutritionistList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserNutritionistCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserNutritionistCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserNutritionistUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserNutritionistUpdate(int a)
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
        public async Task<IActionResult> UserAppointmentList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserAppointmentCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserAppointmentCreate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserAppointmentUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserAppointmentUpdate(int a)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserAppointmentDelete()
        {
            return View();
        }

        #endregion
    }
}
