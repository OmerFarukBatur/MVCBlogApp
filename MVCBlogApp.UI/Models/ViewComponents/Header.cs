using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Admin.Dashboard;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class Header : ViewComponent
    {
        private readonly IOperationService _operationService;
        private readonly IMediator _mediator;

        public Header(IOperationService operationService, IMediator mediator)
        {
            _operationService = operationService;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SessionUser user = _operationService.GetUser();
            int messageCount = 0;

            if (user.AuthRole == "Danışan")
            {
                GetDashboardItemListQueryRequest request = new();
                GetDashboardItemListQueryResponse response = await _mediator.Send(request);
                messageCount = response.DailyIncomingMessageCount;
            }
            else if (user.AuthRole == "Admin")
            {
                
            }
            else if (user.AuthRole == "Diyetisyen")
            {

            }

            return View(new{ user.AuthRole,messageCount});
        }
    }
}
