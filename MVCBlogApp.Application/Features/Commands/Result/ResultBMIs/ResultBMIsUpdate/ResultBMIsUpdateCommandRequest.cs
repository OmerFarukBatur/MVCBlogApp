using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsUpdate
{
    public class ResultBMIsUpdateCommandRequest : IRequest<ResultBMIsUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string IntervalMin { get; set; }
        public string IntervalMax { get; set; }
        public string IntervalDescription { get; set; }
    }
}