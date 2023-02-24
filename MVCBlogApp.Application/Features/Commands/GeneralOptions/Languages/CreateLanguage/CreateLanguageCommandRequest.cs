using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.CreateLanguage
{
    public class CreateLanguageCommandRequest : IRequest<CreateLanguageCommandResponse>
    {
        public string Language { get; set; }
    }
}