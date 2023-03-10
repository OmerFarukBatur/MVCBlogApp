using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsUpdate
{
    public class ResultBMhsUpdateCommandRequest : IRequest<ResultBMhsUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string ResultText { get; set; }
    }
}