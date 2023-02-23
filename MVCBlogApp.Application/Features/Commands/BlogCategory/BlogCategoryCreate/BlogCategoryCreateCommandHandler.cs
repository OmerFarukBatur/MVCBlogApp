using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate
{
    public class BlogCategoryCreateCommandHandler : IRequestHandler<BlogCategoryCreateCommandRequest, BlogCategoryCreateCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogCategoryCreateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogCategoryCreateCommandResponse> Handle(BlogCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BlogCategoryCreateCommandValidator validationRules = new();
            ValidationResult validationResult = validationRules.Validate(new ViewModels.VM_BlogCategory 
            { 
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                StatusID = request.StatusId,
                LangID = request.LangId
            });

            if (validationResult.IsValid)
            {
                return await _blogService.BlogCategoryCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli veriler giriniz",
                    State = false
                };
            }
        }
    }
}
