using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesCreate
{
    public class ResultPulsesCreateCommandRequest : IRequest<ResultPulsesCreateCommandResponse>
    {
        public string ResultMaxText { get; set; }
        public string ResultMinText { get; set; }
    }
}