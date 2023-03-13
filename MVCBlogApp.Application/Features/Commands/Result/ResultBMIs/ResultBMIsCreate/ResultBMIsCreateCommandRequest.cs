using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsCreate
{
    public class ResultBMIsCreateCommandRequest : IRequest<ResultBMIsCreateCommandResponse>
    {
        public string IntervalMin { get; set; }
        public string IntervalMax { get; set; }
        public string IntervalDescription { get; set; }
    }
}