using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetByIdForm
{
    public class GetByIdFormQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Form? Form { get; set; }
        public List<VM_Language> Languages { get; set; }
    }
}