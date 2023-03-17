using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinDelete
{
    public class NewsBulletinDeleteCommandHandler : IRequestHandler<NewsBulletinDeleteCommandRequest, NewsBulletinDeleteCommandResponse>
    {
        private readonly INewsService _newsService;

        public NewsBulletinDeleteCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<NewsBulletinDeleteCommandResponse> Handle(NewsBulletinDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _newsService.NewsBulletinDeleteAsync(request.Id);
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
