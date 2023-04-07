using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.GeneralOptions.Form.GetAllForms
{
    public class GetAllFormsQueryResponse
    {
        public List<VM_Form> Forms { get; set; }
    }
}