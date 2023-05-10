using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Day.GetByIdDay
{
    public class GetByIdDayQueryRequest : IRequest<GetByIdDayQueryResponse>
    {
        public int Id { get; set; }
    }
}