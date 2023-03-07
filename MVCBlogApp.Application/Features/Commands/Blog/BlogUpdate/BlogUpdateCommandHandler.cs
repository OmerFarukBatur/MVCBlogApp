using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Blog.BlogUpdate
{
    public class BlogUpdateCommandHandler : IRequestHandler<BlogUpdateCommandRequest, BlogUpdateCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogUpdateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogUpdateCommandResponse> Handle(BlogUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            BlogUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _blogService.BlogUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
