using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.CreateLanguage
{
    public class CreateLanguageCommandRequest : IRequest<CreateLanguageCommandResponse>
    {
        public string Language { get; set; }
    }
}