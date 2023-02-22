using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate
{
    public class BlogTypeCreateCommandHandler : IRequestHandler<BlogTypeCreateCommandRequest, BlogTypeCreateCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogTypeCreateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogTypeCreateCommandResponse> Handle(BlogTypeCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BlogTypeCreateCommandValidator validations = new();
            ValidationResult validationResult = validations.Validate(request);

            if (validationResult.IsValid)
            {
                return await _blogService.BlogTypeCreateAsync(request);
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
