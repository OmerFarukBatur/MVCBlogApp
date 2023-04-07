using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormCreate
{
    public class FormCreateCommandRequest : IRequest<FormCreateCommandResponse>
    {
        public string FormName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int LangId { get; set; }
    }
}