using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Doctor.Dashboard
{
    public class GetDoctorDashboardItemListQueryRequest : IRequest<GetDoctorDashboardItemListQueryResponse>
    {
        public int Id { get; set; }
    }
}