using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultOptimums.ResultOptimumsUpdate
{
    public class ResultOptimumsUpdateCommandRequest : IRequest<ResultOptimumsUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Result1text { get; set; }
        public string Result2text { get; set; }
        public string Result3text { get; set; }
        public string Result4text { get; set; }
    }
}