using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate
{
    public class BlogTypeUpdateCommandHandler : IRequestHandler<BlogTypeUpdateCommandRequest, BlogTypeUpdateCommandResponse>
    {
        private readonly IBlogService _blogService;

        public BlogTypeUpdateCommandHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<BlogTypeUpdateCommandResponse> Handle(BlogTypeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            BlogTypeUpdateCommandValidator validationRules = new();
            ValidationResult validation = validationRules.Validate(new ViewModels.VM_BlogType { Id = request.Id, TypeName = request.TypeName });

            if (validation.IsValid)
            {
                return await _blogService.BlogTypeUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Lütfen geçerli degerler giriniz."
                };
            }
        }
    }
}
