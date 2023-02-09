using MVCBlogApp.Application.Repositories.D_Appointment;
using MVCBlogApp.Persistence.Contexts;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Repositories.D_Appointment
{
    public class D_AppointmentReadRepository : ReadRepository<E.D_Appointment>, ID_AppointmentReadRepository
    {
        public D_AppointmentReadRepository(MVCBlogDbContext context) : base(context)
        {
        }
    }
}
