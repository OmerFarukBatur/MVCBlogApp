using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMIs.ResultBMIsDelete
{
    public class ResultBMIsDeleteCommandRequest : IRequest<ResultBMIsDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}