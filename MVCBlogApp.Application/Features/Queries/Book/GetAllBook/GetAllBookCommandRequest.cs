using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookCommandRequest : IRequest<GetAllBookCommandResponse>
    {
    }
}