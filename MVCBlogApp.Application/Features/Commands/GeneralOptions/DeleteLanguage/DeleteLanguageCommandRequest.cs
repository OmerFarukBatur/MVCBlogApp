using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.DeleteLanguage
{
    public class DeleteLanguageCommandRequest : IRequest<DeleteLanguageCommandResponse>
    {
        public int Id { get; set; }
    }
}