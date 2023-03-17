using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsPaper.NewsPaperDelete
{
    public class NewsPaperDeleteCommandHandler : IRequestHandler<NewsPaperDeleteCommandRequest, NewsPaperDeleteCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsPaperDeleteCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsPaperDeleteCommandResponse> Handle(NewsPaperDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _newsService.NewsPaperDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
