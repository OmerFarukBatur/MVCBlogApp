using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerUpdate
{
    public class InfluencerUpdateCommandRequest : IRequest<InfluencerUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string Message { get; set; }
        public int StatusId { get; set; }
    }
}