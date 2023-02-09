using MVCBlogApp.Application.Repositories.AppointmentDetail;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.AppointmentDetail
{
    public class AppointmentDetailWriteRepository : WriteRepository<E.AppointmentDetail>, IAppointmentDetailWriteRepository
    {
        public AppointmentDetailWriteRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
