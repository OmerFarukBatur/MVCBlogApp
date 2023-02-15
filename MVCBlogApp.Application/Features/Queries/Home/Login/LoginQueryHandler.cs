using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Home.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        private readonly IAuthService _authService;

        public LoginQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            LoginQueryValidator validations = new();
            ValidationResult result = validations.Validate(request);

            if (result.IsValid)
            {
                return await _authService.Login(request);
            }
            else
            {
                return new LoginQueryResponse() 
                { 
                    Message = "Girilen şifre veya email hatalı"
                };
            }
           
        }
    }
}
