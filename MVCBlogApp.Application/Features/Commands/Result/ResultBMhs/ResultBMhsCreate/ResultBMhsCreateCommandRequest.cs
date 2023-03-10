using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Result.ResultBMhs.ResultBMhsCreate
{
    public class ResultBMhsCreateCommandRequest : IRequest<ResultBMhsCreateCommandResponse>
    {
        public string ResultText { get; set; }
    }
}