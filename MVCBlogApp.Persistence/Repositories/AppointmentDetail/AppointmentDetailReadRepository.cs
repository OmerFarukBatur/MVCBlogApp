using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.AppointmentDetail
{
    public class AppointmentDetailReadRepository : ReadRepository<E.AppointmentDetail>, IAppointmentDetailReadRepository
    {
        public AppointmentDetailReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
