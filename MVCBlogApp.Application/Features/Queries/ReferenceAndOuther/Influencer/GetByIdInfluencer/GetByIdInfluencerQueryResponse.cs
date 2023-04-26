using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetByIdInfluencer
{
    public class GetByIdInfluencerQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_Influencer? Influencer { get; set; }
        public List<AllStatus>? Statuses { get; set; }
    }
}