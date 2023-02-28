using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationDelete
{
    public class NavigationDeleteCommandRequest : IRequest<NavigationDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}