using MediatR;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerCreate
{
    public class InfluencerCreateCommandRequest : IRequest<InfluencerCreateCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanySector { get; set; }
        public string Message { get; set; }
        public int StatusId { get; set; }
    }
}