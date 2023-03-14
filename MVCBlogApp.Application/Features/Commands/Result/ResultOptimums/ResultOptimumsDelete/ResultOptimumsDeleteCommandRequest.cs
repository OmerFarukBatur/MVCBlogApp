using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsDelete
{
    public class ResultOptimumsDeleteCommandRequest : IRequest<ResultOptimumsDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}