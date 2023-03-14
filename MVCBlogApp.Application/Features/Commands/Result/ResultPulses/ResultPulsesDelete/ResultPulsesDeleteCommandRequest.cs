using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultPulses.ResultPulsesDelete
{
    public class ResultPulsesDeleteCommandRequest : IRequest<ResultPulsesDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}