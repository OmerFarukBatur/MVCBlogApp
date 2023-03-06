using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Blog.BlogCreate
{
    public class BlogCreateCommandHandler : IRequestHandler<BlogCreateCommandRequest, BlogCreateCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogCreateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogCreateCommandResponse> Handle(BlogCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BlogCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _blogService.BlogCreateAsync(request);
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
