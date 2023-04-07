using MediatR;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Form.FormUpdate
{
    public class FormUpdateQueryRequest : IRequest<FormUpdateQueryResponse>
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int LangId { get; set; }
    }
}