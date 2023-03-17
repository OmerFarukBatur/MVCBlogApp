using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinUpdate
{
    public class NewsBulletinUpdateCommandHandler : IRequestHandler<NewsBulletinUpdateCommandRequest, NewsBulletinUpdateCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsBulletinUpdateCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsBulletinUpdateCommandResponse> Handle(NewsBulletinUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            NewsBulletinUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _newsService.NewsBulletinUpdateAsync(request);
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
