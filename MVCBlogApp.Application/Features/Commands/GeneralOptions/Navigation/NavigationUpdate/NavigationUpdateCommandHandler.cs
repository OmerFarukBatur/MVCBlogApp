
using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate
{
    public class NavigationUpdateCommandHandler : IRequestHandler<NavigationUpdateCommandRequest, NavigationUpdateCommandResponse>
    {
        private readonly IGeneralOptionsService _generalOptionsService;

        public NavigationUpdateCommandHandler(IGeneralOptionsService generalOptionsService)
        {
            _generalOptionsService = generalOptionsService;
        }

        public async Task<NavigationUpdateCommandResponse> Handle(NavigationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            NavigationUpdateCommandValidator validationRules = new();
            ValidationResult result = validationRules.Validate(request);

            if (result.IsValid)
            {
                return await _generalOptionsService.NavigationUpdateAsync(request);
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
