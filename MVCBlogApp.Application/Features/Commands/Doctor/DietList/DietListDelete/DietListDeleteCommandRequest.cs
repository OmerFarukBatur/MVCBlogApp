using MediatR;

namespace MVCBlogApp.Application.Features.Commands.Doctor.DietList.DietListDelete
{
    public class DietListDeleteCommandRequest : IRequest<DietListDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}