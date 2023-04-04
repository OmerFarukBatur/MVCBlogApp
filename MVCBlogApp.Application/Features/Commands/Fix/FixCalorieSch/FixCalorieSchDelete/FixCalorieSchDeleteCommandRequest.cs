using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchDelete
{
    public class FixCalorieSchDeleteCommandRequest : IRequest<FixCalorieSchDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}