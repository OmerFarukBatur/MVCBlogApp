using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate
{
    public class NewsBulletinCreateCommandHandler : IRequestHandler<NewsBulletinCreateCommandRequest, NewsBulletinCreateCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsBulletinCreateCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsBulletinCreateCommandResponse> Handle(NewsBulletinCreateCommandRequest request, CancellationToken cancellationToken)
        {
            NewsBulletinCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _newsService.NewsBulletinCreateAsync(request);
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
