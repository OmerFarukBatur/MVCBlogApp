using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.Confession.ConfessionUpdate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.ConsultancyFormType.CFTUpdate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserCreate;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserDelete;
using MVCBlogApp.Application.Features.Commands.UserIslemleri.User.UserUpdate;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetAllConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetByIdConfession;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.Confession.GetConfessionCreateItems;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyForm.GetAllConsultancyForm;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetAllCFT;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.ConsultancyFormType.GetByIdCFT;
using MVCBlogApp.Application.Features.Queries.UserIslemleri.MemberAppointment.GetAllMemberAppointment;
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

        #region MemberNutritionist

        [HttpGet]
        public async Task<IActionResult> MemberNutritionistList()
        {
            return View();
        }        

        #endregion

        #region MemberAppointment

        [HttpGet]
        public async Task<IActionResult> MemberAppointmentList(GetAllMemberAppointmentQueryRequest request)
        {
            GetAllMemberAppointmentQueryResponse response = await _mediator.Send(request); /// Detay tarafı yapılacak
            return View(response.D_Appointments);
        }        

        #endregion

        #region Confession

        [HttpGet]
        public async Task<IActionResult> ConfessionList(GetAllConfessionQueryRequest request)
        {
            GetAllConfessionQueryResponse response = await _mediator.Send(request);
            return View(response.Confessions);
        }

        [HttpGet]
        public async Task<IActionResult> ConfessionCreate(GetConfessionCreateItemsQueryRequest request)
        {
            GetConfessionCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ConfessionCreate(ConfessionCreateCommandRequest request)
        {
            ConfessionCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ConfessionList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("ConfessionCreate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfessionUpdate(GetByIdConfessionQueryRequest request)
        {
            GetByIdConfessionQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ConfessionList", "UserIslemleri");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfessionUpdate(ConfessionUpdateCommandRequest request)
        {
            ConfessionUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ConfessionList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("ConfessionUpdate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfessionDelete(ConfessionDeleteCommandRequest request)
        {
            ConfessionDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ConfessionList", "UserIslemleri");
        }

        #endregion

        #region ConsultancyFormType

        [HttpGet]
        public async Task<IActionResult> ConsultancyFormTypeList(GetAllCFTQueryRequest request)
        {
            GetAllCFTQueryResponse response = await _mediator.Send(request);
            return View(response.ConsultancyFormTypes);
        }

        [HttpGet]
        public IActionResult ConsultancyFormTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConsultancyFormTypeCreate(CFTCreateCommandRequest request)
        {
            CFTCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ConsultancyFormTypeList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("ConsultancyFormTypeCreate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultancyFormTypeUpdate(GetByIdCFTQueryRequest request)
        {
            GetByIdCFTQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ConsultancyFormTypeList", "UserIslemleri");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConsultancyFormTypeUpdate(CFTUpdateCommandRequest request)
        {
            CFTUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ConsultancyFormTypeList", "UserIslemleri");
            }
            else
            {
                return RedirectToAction("ConsultancyFormTypeUpdate", "UserIslemleri");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultancyFormTypeDelete(CFTDeleteCommandRequest request)
        {
            CFTDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ConsultancyFormTypeList", "UserIslemleri");
        }

        #endregion

        #region ConsultancyForm

        [HttpGet]
        public async Task<IActionResult> ConsultancyFormList(GetAllConsultancyFormQueryRequest request)
        {
            GetAllConsultancyFormQueryResponse response = await _mediator.Send(request);
            return View(response.ConsultancyForms);
        }

        #endregion
    }
}
