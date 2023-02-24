using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationCreate
{
    public class NavigationCreateCommandHandler : IRequestHandler<NavigationCreateCommandRequest, NavigationCreateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public NavigationCreateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<NavigationCreateCommandResponse> Handle(NavigationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            NavigationCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _generalOptionsService.NavigationCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli veriler giriniz.",
                    State = false
                };
            }           
        }
    }
}
