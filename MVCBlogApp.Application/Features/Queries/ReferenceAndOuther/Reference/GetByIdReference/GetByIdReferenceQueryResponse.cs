using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetByIdReference
{
    public class GetByIdReferenceQueryResponse
    {
        public VM_References? References { get; set; }
        public List<AllStatus>? Statuses { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}