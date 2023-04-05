using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeDelete
{
    public class FixMealSizeDeleteCommandRequest : IRequest<FixMealSizeDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}