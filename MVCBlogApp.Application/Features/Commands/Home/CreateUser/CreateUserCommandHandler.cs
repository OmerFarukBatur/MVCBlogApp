using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Home.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IAuthService  _authService;

        public CreateUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserCommandValidator validations = new();
            ValidationResult result = validations.Validate(request);
            if (result.IsValid)
            {
                var response = await _authService.CreateUserAsync(request);
                return response;
            }
            else
            {
                return new CreateUserCommandResponse() 
                { 
                    Message = "Girilen bilgiler geçerli değil lüften tekrardan gerekli alanları doldurunuz.",
                    StatusCode = false
                };
            }
            
        }
    }
}
