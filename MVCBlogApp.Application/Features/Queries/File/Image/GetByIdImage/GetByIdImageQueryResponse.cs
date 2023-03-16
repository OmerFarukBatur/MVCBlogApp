using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.File.Image.GetByIdImage
{
    public class GetByIdImageQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public List<VM_Language>? Languages { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public VM_Image? Image { get; set; }
    }
}