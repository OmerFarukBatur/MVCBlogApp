using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Blog.BlogDelete
{
    public class BlogDeleteCommandHandler : IRequestHandler<BlogDeleteCommandRequest, BlogDeleteCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogDeleteCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogDeleteCommandResponse> Handle(BlogDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.BlogDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
