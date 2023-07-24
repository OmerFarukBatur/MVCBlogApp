using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCBlogApp.Application.Features.Queries.UIBlog.SimilarSubjects;

namespace MVCBlogApp.UI.Models.ViewComponents
{
    public class SimilarSubjects : ViewComponent
    {
        private readonly IMediator _mediator;

        public SimilarSubjects(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            SimilarSubjectsQueryRequest request = new()
            {
                blogID = blogID
            };
            SimilarSubjectsQueryResponse response = await _mediator.Send(request);

            return View(response.Blogs);
        }
    }
}
