using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperUpdate
{
    public class NewsPaperUpdateCommandHandler : IRequestHandler<NewsPaperUpdateCommandRequest, NewsPaperUpdateCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsPaperUpdateCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsPaperUpdateCommandResponse> Handle(NewsPaperUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            NewsPaperUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _newsService.NewsPaperUpdateAsync(request);
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
