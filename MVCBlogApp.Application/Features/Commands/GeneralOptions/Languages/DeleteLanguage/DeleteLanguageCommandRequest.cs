using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Languages.DeleteLanguage
{
    public class DeleteLanguageCommandRequest : IRequest<DeleteLanguageCommandResponse>
    {
        public int Id { get; set; }
    }
}