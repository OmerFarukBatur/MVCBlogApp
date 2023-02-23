using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryDelete
{
    public class BlogCategoryDeleteCommandHandler : IRequestHandler<BlogCategoryDeleteCommandRequest, BlogCategoryDeleteCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogCategoryDeleteCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogCategoryDeleteCommandResponse> Handle(BlogCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.BlogCategoryDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli degerler giriniz.",
                    State = false
                };
            }
        }
    }
}
