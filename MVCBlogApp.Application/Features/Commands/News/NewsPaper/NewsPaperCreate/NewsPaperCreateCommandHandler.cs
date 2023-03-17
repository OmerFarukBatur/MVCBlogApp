using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperCreate
{
    public class NewsPaperCreateCommandHandler : IRequestHandler<NewsPaperCreateCommandRequest, NewsPaperCreateCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsPaperCreateCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsPaperCreateCommandResponse> Handle(NewsPaperCreateCommandRequest request, CancellationToken cancellationToken)
        {
            NewsPaperCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _newsService.NewsPaperCreateAsync(request);
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
