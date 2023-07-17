using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogApp.Application.Features.Commands.IUHome.NewsBulletin
{
    public class NewsBulletinCommandHandler : IRequestHandler<NewsBulletinCommandRequest, NewsBulletinCommandResponse>
    {
        private readonly IUIHomeService _homeService;

        public NewsBulletinCommandHandler(IUIHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<NewsBulletinCommandResponse> Handle(NewsBulletinCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.email != null && new EmailAddressAttribute().IsValid(request.email))
            {
                return await _homeService.NewsBulletinAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli bir email giriniz.",
                    State = false
                };
            }
        }
    }
}
