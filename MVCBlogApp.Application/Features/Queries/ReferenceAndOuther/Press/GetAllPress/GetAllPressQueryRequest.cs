using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetAllPress
{
    public class GetAllPressQueryRequest : IRequest<GetAllPressQueryResponse>
    {
    }
}