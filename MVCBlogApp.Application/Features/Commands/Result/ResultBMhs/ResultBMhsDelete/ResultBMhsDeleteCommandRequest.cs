using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsDelete
{
    public class ResultBMhsDeleteCommandRequest : IRequest<ResultBMhsDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}