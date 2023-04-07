using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormDelete
{
    public class FormDeleteCommandRequest : IRequest<FormDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}