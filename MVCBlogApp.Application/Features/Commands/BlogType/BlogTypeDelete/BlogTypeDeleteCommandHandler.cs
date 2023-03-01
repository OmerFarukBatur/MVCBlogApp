using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete
{
    public class BlogTypeDeleteCommandHandler : IRequestHandler<BlogTypeDeleteCommandRequest, BlogTypeDeleteCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogTypeDeleteCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogTypeDeleteCommandResponse> Handle(BlogTypeDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _blogService.BlogTypeDeleteAsync(request);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Lütfen geçerli değerler giriniz."
                };
            }
        }
    }
}
