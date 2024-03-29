﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.PressType.PressTypeUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsCreate;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsDelete;
using MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetAllInfluencer;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetByIdInfluencer;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetInfluencerCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetAllOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetByIdOurTeam;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.OurTeam.GetOurTeamCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetAllPress;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetByIdPress;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetPressCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetAllPressType;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetByIdPressType;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetAllReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetAllSeminarVisuals;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetByIdSeminarVisual;
using MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetSeminarVisualsCreateItems;

namespace MVCBlogApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReferenceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOperationService _operationService;

        public ReferenceController(IMediator mediator, IOperationService operationService)
        {
            _mediator = mediator;
            _operationService = operationService;
        }

        #region Reference

        [HttpGet]
        public async Task<IActionResult> ReferenceList(GetAllReferenceQueryRequest request)
        {
            GetAllReferenceQueryResponse response = await _mediator.Send(request);
            return View(response.References);
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceCreate(GetReferenceCreateItemsQueryRequest request)
        {
            GetReferenceCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ReferenceCreate(ReferenceCreateCommandRequest request)
        {
            request.CreatedUserId = _operationService.GetUser().Id;
            ReferenceCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ReferenceList", "Reference");
            }
            else
            {
                return RedirectToAction("ReferenceCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceUpdate(GetByIdReferenceQueryRequest request)
        {
            GetByIdReferenceQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("ReferenceList", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReferenceUpdate(ReferenceUpdateCommandRequest request)
        {
            ReferenceUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("ReferenceList", "Reference");
            }
            else
            {
                return RedirectToAction("ReferenceUpdate", "Reference");
            }
        }

        public async Task<IActionResult> ReferenceDelete(ReferenceDeleteCommandRequest request)
        {
            ReferenceDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("ReferenceList", "Reference");
        }

        #endregion

        #region RoxyFileman

        [HttpGet]
        public async Task<IActionResult> RoxyFilemanIndex()
        {
            return View();
        }

        #endregion

        #region SeminarVisuals

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsList(GetAllSeminarVisualsQueryRequest request)
        {
            GetAllSeminarVisualsQueryResponse response = await _mediator.Send(request);
            return View(response.SeminarVisuals);
        }

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsCreate(GetSeminarVisualsCreateItemsQueryRequest request)
        {
            GetSeminarVisualsCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SeminarVisualsCreate(SeminarVisualsCreateCommandRequest request)
        {
            SeminarVisualsCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("SeminarVisualsList", "Reference");
            }
            else
            {
                return RedirectToAction("SeminarVisualsCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SeminarVisualsUpdate(GetByIdSeminarVisualQueryRequest request)
        {
            GetByIdSeminarVisualQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("SeminarVisualsList", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SeminarVisualsUpdate(SeminarVisualsUpdateCommandRequest request)
        {
            SeminarVisualsUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("SeminarVisualsList", "Reference");
            }
            else
            {
                return RedirectToAction("SeminarVisualsUpdate", "Reference");
            }
        }

        public async Task<IActionResult> SeminarVisualsDelete(SeminarVisualsDeleteCommandRequest request)
        {
            SeminarVisualsDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("SeminarVisualsList", "Reference");
        }

        #endregion

        #region OurTeam

        [HttpGet]
        public async Task<IActionResult> OurTeamList(GetAllOurTeamCommandRequest request)
        {
            GetAllOurTeamCommandResponse response = await _mediator.Send(request);
            return View(response.OurTeams);
        }

        [HttpGet]
        public async Task<IActionResult> OurTeamCreate(GetOurTeamCreateItemsQueryRequest request)
        {
            GetOurTeamCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> OurTeamCreate(OurTeamCreateCommandRequest request)
        {
            request.CreateUserId = _operationService.GetUser().Id;
            OurTeamCreateCommandResponse response = await _mediator.Send(request);

            if (response.State)
            {
                return RedirectToAction("OurTeamList", "Reference");
            }
            else
            {
                return RedirectToAction("OurTeamCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OurTeamUpdate(GetByIdOurTeamQueryRequest request)
        {
            GetByIdOurTeamQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("OurTeamList", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> OurTeamUpdate(OurTeamUpdateCommandRequest request)
        {
            OurTeamUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("OurTeamList", "Reference");
            }
            else
            {
                return RedirectToAction("OurTeamUpdate", "Reference");
            }
        }

        public async Task<IActionResult> OurTeamDelete(OurTeamDeleteCommandRequest request)
        {
            OurTeamDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("OurTeamList", "Reference");
        }

        #endregion

        #region Press

        [HttpGet]
        public async Task<IActionResult> PressList(GetAllPressQueryRequest request)
        {
            GetAllPressQueryResponse response = await _mediator.Send(request);
            return View(response.Presses);
        }

        [HttpGet]
        public async Task<IActionResult> PressCreate(GetPressCreateItemsQueryRequest request)
        {
            GetPressCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> PressCreate(PressCreateCommandRequest request)
        {
            PressCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("PressList", "Reference");
            }
            else
            {
                return RedirectToAction("PressCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> PressUpdate(GetByIdPressQueryRequest request)
        {
            GetByIdPressQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("PressList", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PressUpdate(PressUpdateCommandRequest request)
        {
            PressUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("PressList", "Reference");
            }
            else
            {
                return RedirectToAction("PressUpdate", "Reference");
            }
        }

        public async Task<IActionResult> PressDelete(PressDeleteCommandRequest request)
        {
            PressDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("PressList", "Reference");
        }

        #endregion

        #region PressType

        [HttpGet]
        public async Task<IActionResult> PressTypeList(GetAllPressTypeQueryRequest request)
        {
            GetAllPressTypeQueryResponse response = await _mediator.Send(request);
            return View(response.PressTypes);
        }

        [HttpGet]
        public IActionResult PressTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PressTypeCreate(PressTypeCreateCommandRequest request)
        {
            PressTypeCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("PressTypeList", "Reference");
            }
            else
            {
                return RedirectToAction("PressTypeCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> PressTypeUpdate(GetByIdPressTypeQueryRequest request)
        {
            GetByIdPressTypeQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response.PressType);
            }
            else
            {
                return RedirectToAction("PressTypeCreate", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PressTypeUpdate(PressTypeUpdateCommandRequest request)
        {
            PressTypeUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("PressTypeList", "Reference");
            }
            else
            {
                return RedirectToAction("PressTypeUpdate", "Reference");
            }
        }

        public async Task<IActionResult> PressTypeDelete(PressTypeDeleteCommandRequest request)
        {
            PressTypeDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("PressTypeList", "Reference");
        }

        #endregion

        #region Influencer

        [HttpGet]
        public async Task<IActionResult> InfluencerList(GetAllInfluencerQueryRequest request)
        {
            GetAllInfluencerQueryResponse response = await _mediator.Send(request);
            return View(response.Influencers);
        }

        [HttpGet]
        public async Task<IActionResult> InfluencerCreate(GetInfluencerCreateItemsQueryRequest request)
        {
            GetInfluencerCreateItemsQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> InfluencerCreate(InfluencerCreateCommandRequest request)
        {
            InfluencerCreateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("InfluencerList", "Reference");
            }
            else
            {
                return RedirectToAction("InfluencerCreate", "Reference");
            }
        }

        [HttpGet]
        public async Task<IActionResult> InfluencerUpdate(GetByIdInfluencerQueryRequest request)
        {
            GetByIdInfluencerQueryResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("InfluencerUpdate", "Reference");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InfluencerUpdate(InfluencerUpdateCommandRequest request)
        {
            InfluencerUpdateCommandResponse response = await _mediator.Send(request);
            if (response.State)
            {
                return RedirectToAction("InfluencerList", "Reference");
            }
            else
            {
                return RedirectToAction("InfluencerUpdate", "Reference");
            }
        }

        public async Task<IActionResult> InfluencerDelete(InfluencerDeleteCommandRequest request)
        {
            InfluencerDeleteCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("InfluencerList", "Reference");
        }

        #endregion
    }
}
