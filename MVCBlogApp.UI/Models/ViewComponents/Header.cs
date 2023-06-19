using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Queries.Admin.Header;
using MVCBlogApp.Application.Features.Queries.Member.Header;
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
            string ImageUrl = "";

            if (user.AuthRole == "Admin")
            {
                GetAdminHeaderDataQueryRequest request = new();
                GetAdminHeaderDataQueryResponse response = await _mediator.Send(request);
                messageCount = response.DailyIncomingMessageCount;
            }
            else if (user.AuthRole == "Danışan")
            {
                GetByUserImageQueryRequest getByUserImageQueryRequest = new();
                getByUserImageQueryRequest.Id = user.Id;
                GetByUserImageQueryResponse getByUserImageQueryResponse = await _mediator.Send(getByUserImageQueryRequest); 
                ImageUrl = getByUserImageQueryResponse.ImageUrl;
            }

            return View(new{ user.AuthRole,messageCount,ImageUrl});
        }
    }
}
