using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Queries.UIBlog.TagCloudAndSocialMedia;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class TagCloudAndSocialMedia : ViewComponent
    {
        private readonly IMediator _mediator;

        public TagCloudAndSocialMedia(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            TagCloudAndSocialMediaQueryRequest request = new()
            {
                id = id
            };
            TagCloudAndSocialMediaQueryResponse response = await _mediator.Send(request);

            return View(response.BlogCategories);
        }
    }
}
