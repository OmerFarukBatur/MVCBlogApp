using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesUpdate
{
    public class ResultPulsesUpdateCommandRequest : IRequest<ResultPulsesUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string ResultMaxText { get; set; }
        public string ResultMinText { get; set; }
    }
}