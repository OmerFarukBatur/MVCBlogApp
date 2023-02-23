using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate
{
    public class BlogCategoryUpdateQueryHandler : IRequestHandler<BlogCategoryUpdateQueryRequest, BlogCategoryUpdateQueryResponse>
    {
        private readonly IBlogService _blogService;

        public BlogCategoryUpdateQueryHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogCategoryUpdateQueryResponse> Handle(BlogCategoryUpdateQueryRequest request, CancellationToken cancellationToken)
        {
            BlogCategoryUpdateQueryValidator rules = new();
            ValidationResult validationResult = rules.Validate(request);

            if (validationResult.IsValid)
            {
                return await _blogService.BlogCategoryUpdateAsync(request);
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
