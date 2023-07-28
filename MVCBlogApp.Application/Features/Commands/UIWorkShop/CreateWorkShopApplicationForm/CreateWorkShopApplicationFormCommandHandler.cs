using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.UIWorkShop.CreateWorkShopApplicationForm
{
    public class CreateWorkShopApplicationFormCommandHandler : IRequestHandler<CreateWorkShopApplicationFormCommandRequest, CreateWorkShopApplicationFormCommandResponse>
    {
        private readonly IUIOtherService _uIOtherService;

        public CreateWorkShopApplicationFormCommandHandler(IUIOtherService uIOtherService)
        {
            _uIOtherService = uIOtherService;
        }

        public async Task<CreateWorkShopApplicationFormCommandResponse> Handle(CreateWorkShopApplicationFormCommandRequest request, CancellationToken cancellationToken)
        {
            CreateWorkShopApplicationFormCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _uIOtherService.CreateWorkShopApplicationFormAsync(request);
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
