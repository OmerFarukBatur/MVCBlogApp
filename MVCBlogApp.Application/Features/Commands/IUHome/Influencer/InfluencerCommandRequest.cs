using MediatR;

namespace MVCBlogApp.Application.Features.Commands.IUHome.Influencer
{
    public class InfluencerCommandRequest : IRequest<InfluencerCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string Message { get; set; }
    }
}